using UnityEngine;

public class Soldier : MonoBehaviour
{
    private Transform target;
    
    [Header("Atributos del Soldado")]
    public float range = 3f; // Alcance visual del soldado
    public float fireRate = 1f; // Cadencia de tiro (disparos por segundo)
    private float fireCountdown = 0f;

    [Header("Armamento")]
    public GameObject bulletPrefab; // Ranura para la bala del rifle

    void Update()
    {
        UpdateTarget();

        if (target == null) return;

        // El soldado apunta su arma: Rota hacia el mutante enemigo
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Control del gatillo
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate; // Recarga
        }
        
        fireCountdown -= Time.deltaTime;
    }

    void UpdateTarget()
    {
        // El soldado escanea la zona buscando mutantes (etiqueta "Enemy")
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

        // Si el mutante está a tiro, fija el objetivo
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Shoot()
    {
        // El soldado aprieta el gatillo
        GameObject bulletGO = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
    
    // Dibuja el rango de visión del soldado en el editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}