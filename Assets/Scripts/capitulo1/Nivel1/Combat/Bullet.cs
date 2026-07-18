using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 500f; 

    [Header("Efectos")]
    [Tooltip("El sonido que hace la bala al chocar contra el enemigo")]
    public AudioClip sonidoImpacto;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        Enemy enemigo = target.GetComponent<Enemy>();
        
        if (enemigo != null)
        {
            enemigo.TakeDamage(1); 
        }

        // Reproduce el sonido de impacto creando un parlante invisible temporal
        // ya que la bala se destruirá en la siguiente línea
        if (sonidoImpacto != null)
        {
            AudioSource.PlayClipAtPoint(sonidoImpacto, transform.position);
        }

        Destroy(gameObject);
    }
}