using UnityEngine;
using System.Collections.Generic;

public class ControlSoldados : MonoBehaviour
{
    public static ControlSoldados instance;

    [System.Serializable]
    public class Arma
    {
        [Header("Nombre y Tipo")]
        public string nombreArma = "Fusil";
        public RuntimeAnimatorController animadorArma;

        [Header("Configuración de Munición")]
        public GameObject bulletPrefab;
        public int capacidadCargador = 10;
        public float tiempoDeRecarga = 2f;
        public float cadenciaDisparo = 2f; 
        public float rangoBase = 3f;

        [Header("Efectos")]
        public GameObject efectoExplosion;
        public AudioClip sonidoDisparo;
        public AudioClip sonidoRecarga;

        [HideInInspector] public int balasActuales;
        [HideInInspector] public bool estaRecargando = false;
        [HideInInspector] public float cooldownDisparo = 0f;
        [HideInInspector] public float cooldownRecarga = 0f;
        [HideInInspector] public float rangoActual;
    }

    [System.Serializable]
    public class Soldado
    {
        public string nombre = "Soldado";
        
        [Header("Conexiones Físicas")]
        public Transform transformFisico;
        public Animator animadorSoldado;
        public Transform puntoDeDisparo;

        [Header("Salud del Soldado")]
        public int vidaActual = 15;
        public int vidaMaxima = 15;
        [HideInInspector] public bool estaVivo = true;

        [Header("Cargamento de Armas")]
        public List<Arma> inventarioArmas = new List<Arma>();
        public int indiceArmaActual = 0;

        [HideInInspector] public Transform target;
        [HideInInspector] public AudioSource audioSource;
    }

    [Header("--- GESTIÓN DEL ESCUADRÓN ---")]
    public Soldado[] escuadron;

    private int vidaTotalMaxima = 75; // 5 soldados * 15 de vida
    [HideInInspector] public int vidaTotalActual = 75;

    void Awake()
    {
        instance = this;
    }

    void OnValidate()
    {
        if (escuadron != null)
        {
            foreach (Soldado sol in escuadron)
            {
                if (sol.transformFisico != null)
                {
                    if (sol.animadorSoldado == null) 
                        sol.animadorSoldado = sol.transformFisico.GetComponentInChildren<Animator>();
                    
                    if (sol.puntoDeDisparo == null)
                    {
                        Transform[] hijos = sol.transformFisico.GetComponentsInChildren<Transform>(true);
                        foreach (Transform h in hijos)
                        {
                            if (h.name == "PuntoDisparo")
                            {
                                sol.puntoDeDisparo = h;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }

    void Start()
    {
        // Inicialización de vida global del escuadrón
        vidaTotalActual = 0;
        if (escuadron != null && escuadron.Length > 0)
        {
            vidaTotalMaxima = escuadron.Length * 15;
            foreach (Soldado sol in escuadron)
            {
                sol.vidaMaxima = 15;
                sol.vidaActual = 15;
                sol.estaVivo = true;
                vidaTotalActual += sol.vidaActual;
            }
        }

        Debug.Log($"--- AUDITORÍA DE ESCUADRÓN: Total de soldados detectados = {escuadron.Length} | Vida Total: {vidaTotalActual}/{vidaTotalMaxima} ---");
        GameLogger.LogToFile("ControlSoldados", $"Auditoría inicial del escuadrón. Total de soldados detectados: {escuadron.Length} | Vida Total: {vidaTotalActual}");

        foreach (Soldado sol in escuadron)
        {
            if (sol.transformFisico != null)
            {
                sol.audioSource = sol.transformFisico.GetComponent<AudioSource>();
                if (sol.audioSource == null) sol.audioSource = sol.transformFisico.gameObject.AddComponent<AudioSource>();

                foreach (Arma arma in sol.inventarioArmas)
                {
                    arma.balasActuales = arma.capacidadCargador;
                    arma.estaRecargando = false;
                    arma.rangoActual = arma.rangoBase;

                    // Auditoría individual de balas
                    if (arma.bulletPrefab == null)
                    {
                        Debug.LogError($"[❌ ALERTA MUNICIÓN] ¡Al soldado '{sol.transformFisico.name}' le falta el Bullet Prefab en su arma!");
                        GameLogger.LogToFile("ControlSoldados", $"[ERROR] Al soldado '{sol.transformFisico.name}' le falta el Bullet Prefab en su arma.");
                    }
                    else
                    {
                        Debug.Log($"[✅ OK] El soldado '{sol.transformFisico.name}' tiene su munición lista.");
                        GameLogger.LogToFile("ControlSoldados", $"El soldado '{sol.transformFisico.name}' tiene su munición lista.");
                    }
                }
                ActualizarAnimacionSoldado(sol);
            }
            else
            {
                Debug.LogWarning("[⚠️ ADVERTENCIA] Hay un espacio vacío en el array del escuadrón que no tiene un Transform asignado.");
                GameLogger.LogToFile("ControlSoldados", "[ADVERTENCIA] Hay un espacio vacío en el array del escuadrón sin Transform asignado.");
            }
        }
        ActualizarEstadisticasPorNivel();
        RecalcularVidaTotalGlobal();
    }

    public void RecibirDañoSoldado(int indiceSoldado, int cantidadDaño)
    {
        if (indiceSoldado < 0 || indiceSoldado >= escuadron.Length) return;

        Soldado sol = escuadron[indiceSoldado];
        if (!sol.estaVivo) return;

        sol.vidaActual -= cantidadDaño;
        if (sol.vidaActual <= 0)
        {
            sol.vidaActual = 0;
            sol.estaVivo = false;
            GameLogger.LogToFile("ControlSoldados", $"[BAJA] El soldado '{sol.nombre}' (Índice {indiceSoldado}) ha muerto.");
        }
        else
        {
            GameLogger.LogToFile("ControlSoldados", $"El soldado '{sol.nombre}' recibió {cantidadDaño} de daño. Vida restante: {sol.vidaActual}/15");
        }

        RecalcularVidaTotalGlobal();
    }

    void RecalcularVidaTotalGlobal()
    {
        vidaTotalActual = 0;
        foreach (Soldado sol in escuadron)
        {
            if (sol.vidaActual > 0)
            {
                vidaTotalActual += sol.vidaActual;
            }
        }

        float porcentajeVida = vidaTotalMaxima > 0 ? (float)vidaTotalActual / vidaTotalMaxima : 0f;

        if (GameManager.instance != null)
        {
            GameManager.instance.ActualizarBarraDeVidaGlobal(porcentajeVida);
        }

        GameLogger.LogToFile("ControlSoldados", $"Salud global del escuadrón: {vidaTotalActual}/{vidaTotalMaxima} ({porcentajeVida * 100}%)");
    }

    public void ActualizarEstadisticasPorNivel()
    {
        // Sistema de niveles de soldados deshabilitado (enfocado en Armería)
        foreach (Soldado sol in escuadron)
        {
            foreach (Arma arma in sol.inventarioArmas)
            {
                arma.rangoActual = arma.rangoBase;
            }
        }
    }

    void Update()
    {
        foreach (Soldado sol in escuadron)
        {
            if (!sol.estaVivo || sol.transformFisico == null || sol.inventarioArmas.Count == 0 || sol.indiceArmaActual >= sol.inventarioArmas.Count) 
                continue;

            Arma armaEquipada = sol.inventarioArmas[sol.indiceArmaActual];

            if (armaEquipada.estaRecargando)
            {
                armaEquipada.cooldownRecarga -= Time.deltaTime;
                if (armaEquipada.cooldownRecarga <= 0f)
                {
                    armaEquipada.balasActuales = armaEquipada.capacidadCargador;
                    armaEquipada.estaRecargando = false;
                }
                continue; 
            }

            if (armaEquipada.balasActuales <= 0)
            {
                IniciarRecarga(sol, armaEquipada);
                continue;
            }

            if (armaEquipada.cooldownDisparo > 0f) armaEquipada.cooldownDisparo -= Time.deltaTime;

            UpdateTarget(sol, armaEquipada);

            if (sol.target == null) continue;

            Vector3 dir = sol.target.position - sol.transformFisico.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            sol.transformFisico.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (armaEquipada.cooldownDisparo <= 0f) Shoot(sol, armaEquipada);
        }
    }

    void UpdateTarget(Soldado sol, Arma arma)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(sol.transformFisico.position, enemy.transform.position);
            
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= arma.rangoActual) 
        {
            sol.target = nearestEnemy.transform;
        }
        else 
        {
            sol.target = null;
        }
    }

    void Shoot(Soldado sol, Arma arma)
    {
        if (arma.balasActuales <= 0)
        {
            IniciarRecarga(sol, arma);
            return;
        }

        Vector3 origenDisparo = sol.puntoDeDisparo != null ? sol.puntoDeDisparo.position : sol.transformFisico.position;

        if (arma.bulletPrefab != null)
        {
            GameObject bulletGO = Instantiate(arma.bulletPrefab, origenDisparo, Quaternion.identity);
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            if (bullet != null) bullet.Seek(sol.target);
        }

        if (arma.efectoExplosion != null)
        {
            GameObject fx = Instantiate(arma.efectoExplosion, origenDisparo, Quaternion.identity);
            Destroy(fx, 1.5f); 
        }

        if (arma.sonidoDisparo != null && sol.audioSource != null) sol.audioSource.PlayOneShot(arma.sonidoDisparo);

        arma.balasActuales--; 
        arma.cooldownDisparo = arma.cadenciaDisparo > 0 ? 1f / arma.cadenciaDisparo : 1f;

        GameLogger.LogToFile("ControlSoldados", $"El soldado {sol.transformFisico.name} disparó con éxito. Arma: {arma.nombreArma} | Balas restantes: {arma.balasActuales}");
    }

    void IniciarRecarga(Soldado sol, Arma arma)
    {
        arma.estaRecargando = true;
        arma.cooldownRecarga = arma.tiempoDeRecarga;
        if (arma.sonidoRecarga != null && sol.audioSource != null) sol.audioSource.PlayOneShot(arma.sonidoRecarga);

        GameLogger.LogToFile("ControlSoldados", $"El soldado {sol.transformFisico.name} inició recarga. Arma: {arma.nombreArma}");
    }

    public void CambiarArmaDeSoldado(int indiceSoldado, int indiceArmaNueva)
    {
        if (indiceSoldado >= 0 && indiceSoldado < escuadron.Length)
        {
            Soldado sol = escuadron[indiceSoldado];
            if (indiceArmaNueva >= 0 && indiceArmaNueva < sol.inventarioArmas.Count)
            {
                sol.indiceArmaActual = indiceArmaNueva;
                ActualizarAnimacionSoldado(sol);
                GameLogger.LogToFile("ControlSoldados", $"Arma cambiada en el soldado índice {indiceSoldado}. Nueva arma índice: {indiceArmaNueva}");
            }
            else
            {
                GameLogger.LogToFile("ControlSoldados", $"[ADVERTENCIA] Índice de arma inválido ({indiceArmaNueva}) para el soldado índice {indiceSoldado}.");
            }
        }
        else
        {
            GameLogger.LogToFile("ControlSoldados", $"[ADVERTENCIA] Índice de soldado inválido al cambiar arma: {indiceSoldado}.");
        }
    }

    private void ActualizarAnimacionSoldado(Soldado sol)
    {
        if (sol.animadorSoldado != null && sol.inventarioArmas.Count > 0)
        {
            RuntimeAnimatorController nuevoAnimador = sol.inventarioArmas[sol.indiceArmaActual].animadorArma;
            if (nuevoAnimador != null) sol.animadorSoldado.runtimeAnimatorController = nuevoAnimador;
        }
    }
}