using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10000f;
    
    [Header("Resistencia")]
    public int health = 5; // La cantidad de balas que resiste el mutante

    private Transform target;
    private int waypointIndex = 0;
    private Animator anim;
    
    void Start()
    {
        // Verificamos que existan puntos suficientes en la ruta
        if (Waypoints.points == null || Waypoints.points.Length <= 1) return;

        anim = GetComponent<Animator>();
        
        // Le indicamos que su primer objetivo real es el Punto_1
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

    // Nueva función: El enemigo recibe daño y calcula si debe morir
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // 1. NUEVO: Le quitamos la etiqueta para que los soldados lo ignoren inmediatamente
        gameObject.tag = "Untagged"; 

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

    /// <summary>
    /// Establece la vida inicial del enemigo.
    /// Este método es llamado por el Spawner al instanciar el enemigo.
    /// </summary>
    /// <param name="nuevaVida">La cantidad de vida que tendrá el enemigo.</param>
    public void EstablecerVida(int nuevaVida)
    {
        health = nuevaVida;
        Debug.Log("Vida del enemigo establecida a: " + nuevaVida + " (desde Spawner)");
    }
}