using UnityEngine;

[RequireComponent(typeof(AudioSource))] 
public class Zombiee : MonoBehaviour 
{
    public float speed = 20f;
    
    [Header("Resistencia")]
    public int health = 5; 

    [Header("Efectos de Sonido")]
    public AudioClip sonidoImpacto;
    public AudioClip sonidoMuerte;
    public AudioClip sonidoAmbiente; 

    [Header("Configuración de Ambiente")]
    [Range(0f, 1f)] 
    public float volumenAmbiente = 1f; 
    
    public float tiempoMinGruñido = 3f; 
    public float tiempoMaxGruñido = 8f; 
    private float timerGruñido;

    private Transform[] misPuntosDeRuta; 
    private Transform target;
    private int waypointIndex = 0;
    
    private Animator anim;
    private AudioSource audioSource; 
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timerGruñido = Random.Range(tiempoMinGruñido, tiempoMaxGruñido);
        anim = GetComponent<Animator>();
        GameLogger.LogToFile("Zombiee", $"Zombie inicializado. Vida: {health} | Velocidad: {speed}");

        if (Waypoints.rutas == null || Waypoints.rutas.Length == 0)
        {
            GameLogger.LogToFile("Zombiee", "[ERROR] No existen rutas disponibles en Waypoints.");
            return;
        }

        int rutaAleatoria = Random.Range(0, Waypoints.rutas.Length);
        Transform rutaElegida = Waypoints.rutas[rutaAleatoria];

        misPuntosDeRuta = new Transform[rutaElegida.childCount];
        for (int i = 0; i < misPuntosDeRuta.Length; i++)
        {
            misPuntosDeRuta[i] = rutaElegida.GetChild(i);
        }

        if (misPuntosDeRuta.Length > 0)
        {
            transform.position = misPuntosDeRuta[0].position;
        }

        if (misPuntosDeRuta.Length > 1)
        {
            waypointIndex = 1; 
            target = misPuntosDeRuta[waypointIndex];
        }

        GameLogger.LogToFile("Zombiee", $"Ruta asignada al zombie. Ruta: {rutaElegida.name} | Puntos: {misPuntosDeRuta.Length}");
    }

    void Update()
    {
        if (target == null) return;

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f) 
        {
            GetNextWaypoint();
        }

        if (sonidoAmbiente != null && audioSource != null && health > 0)
        {
            timerGruñido -= Time.deltaTime; 

            if (timerGruñido <= 0f)
            {
                audioSource.PlayOneShot(sonidoAmbiente, volumenAmbiente);
                timerGruñido = Random.Range(tiempoMinGruñido, tiempoMaxGruñido);
            }
        }
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= misPuntosDeRuta.Length - 1)
        {
            GameLogger.LogToFile("Zombiee", "Zombie llegó al final de su ruta y será destruido.");
            Destroy(gameObject);
            return; 
        }

        waypointIndex++;
        target = misPuntosDeRuta[waypointIndex];
        GameLogger.LogToFile("Zombiee", $"Zombie avanzó al waypoint índice {waypointIndex}.");
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        GameLogger.LogToFile("Zombiee", $"Zombie recibió daño: {damage}. Vida restante: {health}");

        if (sonidoImpacto != null && audioSource != null)
        {
            audioSource.PlayOneShot(sonidoImpacto);
        }

        if (health <= 0)
        {
            Die();
        }
    }

    [Header("Configuración de Recompensa")]
    public GameObject prefabRecursoDrop; 

    void Die()
    {
        gameObject.tag = "Untagged"; 

        if (sonidoMuerte != null)
        {
            AudioSource.PlayClipAtPoint(sonidoMuerte, transform.position);
        }

        if (GameManager.instance != null)
        {
            GameManager.instance.RegistrarMuerte();
        }
        
        // --- AQUÍ CLONA EL CRISTAL UNA SOLA VEZ ---
        if (prefabRecursoDrop != null)
        {
            Instantiate(prefabRecursoDrop, transform.position, Quaternion.identity);
            GameLogger.LogToFile("Zombiee", $"[DROP EXITOSO] Recurso generado en la posición: {transform.position}");
        }
        else
        {
            GameLogger.LogToFile("Zombiee", $"[ADVERTENCIA] El zombi murió en {transform.position}, pero 'prefabRecursoDrop' no está asignado en el Inspector.");
        }

        speed = 0;
        if (anim != null)
        {
            bool parameterExists = false;
            foreach (AnimatorControllerParameter param in anim.parameters)
            {
                if (param.name == "TriggerMuerte" && param.type == AnimatorControllerParameterType.Trigger)
                {
                    parameterExists = true;
                    break;
                }
            }

            if (parameterExists)
            {
                anim.SetTrigger("TriggerMuerte");
            }
        }

        // ---> ¡AQUÍ ESTABA EL CÓDIGO REPETIDO! Ya lo borramos. <---

        Destroy(gameObject, 1f); 
    }

    public void EstablecerVida(int nuevaVida)
    {
        health = nuevaVida;
        Debug.Log("Vida del enemigo establecida a: " + nuevaVida + " (desde Spawner)");
        GameLogger.LogToFile("Zombiee", $"Vida del enemigo establecida desde Spawner: {nuevaVida}");
    }
}