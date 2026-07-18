using UnityEngine;

[RequireComponent(typeof(AudioSource))] 
public class Enemy : MonoBehaviour
{
    public float speed = 10000f;
    
    [Header("Resistencia")]
    public int health = 5; 

    [Header("Efectos de Sonido")]
    public AudioClip sonidoImpacto;
    public AudioClip sonidoMuerte;
    // --- NUEVO: Sonido de ambiente/gruñido ---
    public AudioClip sonidoAmbiente; 

    // --- NUEVO: Control del tiempo de gruñidos ---
    [Header("Configuración de Ambiente")]
    public float tiempoMinGruñido = 3f; // Tiempo mínimo antes de volver a gruñir
    public float tiempoMaxGruñido = 8f; // Tiempo máximo
    private float timerGruñido;

    private Transform target;
    private int waypointIndex = 0;
    private Animator anim;
    private AudioSource audioSource; 
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // NUEVO: Le damos un tiempo aleatorio inicial para su primer gruñido
        timerGruñido = Random.Range(tiempoMinGruñido, tiempoMaxGruñido);

        if (Waypoints.points == null || Waypoints.points.Length <= 1) return;

        anim = GetComponent<Animator>();
        
        waypointIndex = 1; 
        target = Waypoints.points[waypointIndex];
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

        // --- NUEVO: Lógica del gruñido durante el transcurso del juego ---
        if (sonidoAmbiente != null && audioSource != null && health > 0)
        {
            timerGruñido -= Time.deltaTime; // El reloj va marcha atrás

            if (timerGruñido <= 0f)
            {
                // Reproduce el gruñido
                audioSource.PlayOneShot(sonidoAmbiente);
                
                // Reinicia el reloj con un nuevo tiempo aleatorio
                timerGruñido = Random.Range(tiempoMinGruñido, tiempoMaxGruñido);
            }
        }
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return; 
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (sonidoImpacto != null && audioSource != null)
        {
            audioSource.PlayOneShot(sonidoImpacto);
        }

        if (health <= 0)
        {
            Die();
        }
    }

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
        
        speed = 0;
        if (anim != null)
        {
            anim.SetTrigger("TriggerMuerte");
        }
        Destroy(gameObject, 1f); 
    }

    public void EstablecerVida(int nuevaVida)
    {
        health = nuevaVida;
        Debug.Log("Vida del enemigo establecida a: " + nuevaVida + " (desde Spawner)");
    }
}