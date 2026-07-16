using UnityEngine;
using System.Collections.Generic;

public class Soldier : MonoBehaviour
{
    // Clase interna para definir los atributos individuales de cada arma
    [System.Serializable]
    public class Arma
    {
        [Header("Nombre y Tipo")]
        public string nombreArma = "Fusil";

        [Header("Configuración de Munición")]
        public GameObject bulletPrefab;
        public int capacidadCargador = 10;
        public float tiempoDeRecarga = 2f;
        public float cadenciaDisparo = 2f; // Balas por segundo

        [Header("Efectos Visuales (Partículas)")]
        [Tooltip("Prefab de la explosión o destello al disparar o impactar.")]
        public GameObject efectoExplosion;

        [Header("Efectos de Sonido (AudioClips)")]
        public AudioClip sonidoDisparo;
        public AudioClip sonidoRecarga;

        [Header("Monitoreo en Tiempo Real (No tocar)")]
        public int balasActuales;
        public bool estaRecargando = false;
        [HideInInspector] public float cooldownDisparo = 0f;
        [HideInInspector] public float cooldownRecarga = 0f;
    }

    private Transform target;

    [Header("Visualización y Rango")]
    public float rangoBase = 3f;      
    public float range;

    [Header("Cargamento de Armas")]
    [Tooltip("Aquí puedes aumentar o disminuir la cantidad de armas del soldado desde Unity.")]
    public List<Arma> inventarioArmas = new List<Arma>();
    
    [Tooltip("El índice del arma que el soldado está usando actualmente (0 es la primera).")]
    public int indiceArmaActual = 0;

    [Header("Componentes de Audio")]
    private AudioSource audioSource;

    void Start()
    {
        range = rangoBase;
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Creamos un AudioSource automáticamente si el soldado no lo tiene
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Registrar soldado en el GameManager
        if (GameManager.instance != null)
        {
            GameManager.instance.soldadosActivos.Add(this);
        }

        // Inicializamos las balas de todas las armas configuradas
        foreach (Arma arma in inventarioArmas)
        {
            arma.balasActuales = arma.capacidadCargador;
            arma.estaRecargando = false;
        }

        ActualizarEstadisticasPorNivel();
    }

    private void OnDestroy()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.soldadosActivos.Remove(this);
        }
    }

    public void ActualizarEstadisticasPorNivel()
    {
        if (GameManager.instance == null) return;
        int nivel = GameManager.instance.nivelSoldados;
        range = rangoBase + ((nivel - 1) * 0.5f);
    }

    void Update()
    {
        // Si no hay armas configuradas, el soldado no puede hacer nada
        if (inventarioArmas.Count == 0 || indiceArmaActual >= inventarioArmas.Count) return;

        Arma armaEquipada = inventarioArmas[indiceArmaActual];

        // 1. Lógica de recarga del arma actual
        if (armaEquipada.estaRecargando)
        {
            armaEquipada.cooldownRecarga -= Time.deltaTime;
            if (armaEquipada.cooldownRecarga <= 0f)
            {
                armaEquipada.balasActuales = armaEquipada.capacidadCargador;
                armaEquipada.estaRecargando = false;
                Debug.Log(gameObject.name + " terminó de recargar: " + armaEquipada.nombreArma);
            }
            return; 
        }

        // Reducimos el tiempo de espera entre balas individuales de esta arma
        if (armaEquipada.cooldownDisparo > 0f)
        {
            armaEquipada.cooldownDisparo -= Time.deltaTime;
        }

        // 2. Buscar objetivos
        UpdateTarget();

        if (target == null) return;

        // Apuntar al enemigo
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // 3. Intentar disparar
        if (armaEquipada.cooldownDisparo <= 0f)
        {
            Shoot(armaEquipada);
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Shoot(Arma arma)
    {
        // Si nos quedamos sin balas en esta arma, iniciamos recarga
        if (arma.balasActuales <= 0)
        {
            IniciarRecarga(arma);
            return;
        }

        // 1. Instanciar la bala
        if (arma.bulletPrefab != null)
        {
            GameObject bulletGO = Instantiate(arma.bulletPrefab, transform.position, Quaternion.identity);
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.Seek(target);
            }
        }

        // 2. Instanciar efectos visuales (Destello de cañón / Explosión de disparo)
        if (arma.efectoExplosion != null)
        {
            GameObject fx = Instantiate(arma.efectoExplosion, transform.position, Quaternion.identity);
            Destroy(fx, 1.5f); // Destruye el efecto visual después de segundo y medio
        }

        // 3. Reproducir el efecto de sonido de disparo
        if (arma.sonidoDisparo != null && audioSource != null)
        {
            audioSource.PlayOneShot(arma.sonidoDisparo);
        }

        arma.balasActuales--; // Gastamos munición
        
        // Cooldown para el próximo disparo según la cadencia
        if (arma.cadenciaDisparo > 0)
        {
            arma.cooldownDisparo = 1f / arma.cadenciaDisparo;
        }
        else
        {
            arma.cooldownDisparo = 1f;
        }
    }

    void IniciarRecarga(Arma arma)
    {
        arma.estaRecargando = true;
        arma.cooldownRecarga = arma.tiempoDeRecarga;

        // Reproducir el efecto de sonido de recarga
        if (arma.sonidoRecarga != null && audioSource != null)
        {
            audioSource.PlayOneShot(arma.sonidoRecarga);
        }

        Debug.Log(gameObject.name + " recargando: " + arma.nombreArma);
    }

    // Función pública para cambiar de arma desde otros scripts si lo necesitas
    public void CambiarArma(int nuevoIndice)
    {
        if (nuevoIndice >= 0 && nuevoIndice < inventarioArmas.Count)
        {
            indiceArmaActual = nuevoIndice;
            Debug.Log(gameObject.name + " cambió al arma: " + inventarioArmas[indiceArmaActual].nombreArma);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}