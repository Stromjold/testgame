using UnityEngine;
using System.Collections.Generic;

public class Soldier : MonoBehaviour
{
    [System.Serializable]
    public class Arma
    {
        [Header("Nombre y Tipo")]
        public string nombreArma = "Fusil";

        [Header("Animación")]
        [Tooltip("Arrastra aquí el Animator Controller específico de esta arma.")]
        public RuntimeAnimatorController animadorArma;

        [Header("Configuración de Munición")]
        public GameObject bulletPrefab;
        public int capacidadCargador = 10;
        public float tiempoDeRecarga = 2f;
        public float cadenciaDisparo = 2f; 

        [Header("Rango del Arma")]
        [Tooltip("El rango específico de esta arma.")]
        public float rangoBase = 3f;

        [Header("Efectos Visuales (Partículas)")]
        public GameObject efectoExplosion;

        [Header("Efectos de Sonido (AudioClips)")]
        public AudioClip sonidoDisparo;
        public AudioClip sonidoRecarga;

        [Header("Monitoreo en Tiempo Real (No tocar)")]
        public int balasActuales;
        public bool estaRecargando = false;
        [HideInInspector] public float cooldownDisparo = 0f;
        [HideInInspector] public float cooldownRecarga = 0f;
        [HideInInspector] public float rangoActual;
    }

    private Transform target;

    [Header("Referencias Visuales")]
    [Tooltip("Arrastra aquí el objeto que contiene el componente Animator del soldado.")]
    public Animator animadorSoldado;

    [Header("Cargamento de Armas")]
    public List<Arma> inventarioArmas = new List<Arma>();
    public int indiceArmaActual = 0;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (GameManager.instance != null)
        {
            GameManager.instance.soldadosActivos.Add(this);
        }

        foreach (Arma arma in inventarioArmas)
        {
            arma.balasActuales = arma.capacidadCargador;
            arma.estaRecargando = false;
            arma.rangoActual = arma.rangoBase;
        }

        ActualizarEstadisticasPorNivel();
        ActualizarAnimacionArma();
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
        foreach (Arma arma in inventarioArmas)
        {
            arma.rangoActual = arma.rangoBase + ((nivel - 1) * 0.5f);
        }
    }

    void Update()
    {
        if (inventarioArmas.Count == 0 || indiceArmaActual >= inventarioArmas.Count) return;

        Arma armaEquipada = inventarioArmas[indiceArmaActual];

        if (armaEquipada.estaRecargando)
        {
            armaEquipada.cooldownRecarga -= Time.deltaTime;
            if (armaEquipada.cooldownRecarga <= 0f)
            {
                armaEquipada.balasActuales = armaEquipada.capacidadCargador;
                armaEquipada.estaRecargando = false;
            }
            return; 
        }

        if (armaEquipada.balasActuales <= 0)
        {
            IniciarRecarga(armaEquipada);
            return;
        }

        if (armaEquipada.cooldownDisparo > 0f)
        {
            armaEquipada.cooldownDisparo -= Time.deltaTime;
        }

        UpdateTarget(armaEquipada);

        if (target == null) return;

        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (armaEquipada.cooldownDisparo <= 0f)
        {
            Shoot(armaEquipada);
        }
    }

    void UpdateTarget(Arma armaEquipada)
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

        if (nearestEnemy != null && shortestDistance <= armaEquipada.rangoActual)
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
        if (arma.balasActuales <= 0)
        {
            IniciarRecarga(arma);
            return;
        }

        if (arma.bulletPrefab != null)
        {
            GameObject bulletGO = Instantiate(arma.bulletPrefab, transform.position, Quaternion.identity);
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.Seek(target);
            }
        }

        if (arma.efectoExplosion != null)
        {
            GameObject fx = Instantiate(arma.efectoExplosion, transform.position, Quaternion.identity);
            Destroy(fx, 1.5f); 
        }

        if (arma.sonidoDisparo != null && audioSource != null)
        {
            audioSource.PlayOneShot(arma.sonidoDisparo);
        }

        arma.balasActuales--; 
        
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

        if (arma.sonidoRecarga != null && audioSource != null)
        {
            audioSource.PlayOneShot(arma.sonidoRecarga);
        }
    }

    public void CambiarArma(int nuevoIndice)
    {
        if (nuevoIndice >= 0 && nuevoIndice < inventarioArmas.Count)
        {
            indiceArmaActual = nuevoIndice;
            ActualizarAnimacionArma();
        }
    }

    private void ActualizarAnimacionArma()
    {
        if (animadorSoldado != null && inventarioArmas.Count > 0)
        {
            RuntimeAnimatorController nuevoAnimador = inventarioArmas[indiceArmaActual].animadorArma;
            if (nuevoAnimador != null)
            {
                animadorSoldado.runtimeAnimatorController = nuevoAnimador;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (inventarioArmas != null && inventarioArmas.Count > 0 && indiceArmaActual < inventarioArmas.Count)
        {
            Gizmos.color = Color.red;
            float rangoDibujo = Application.isPlaying ? inventarioArmas[indiceArmaActual].rangoActual : inventarioArmas[indiceArmaActual].rangoBase;
            Gizmos.DrawWireSphere(transform.position, rangoDibujo);
        }
    }
}