using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Prefab del enemigo que se va a instanciar. Asignar desde el Inspector de Unity.
    public GameObject enemigoPrefab;
    // Tiempo en segundos entre la aparición de cada enemigo en una oleada.
    public float tiempoEntreEnemigos = 1.5f;

    [Header("Configuración de Oleadas")]
    // Número de la oleada actual.
    public int oleadaActual = 1;
    // Cantidad de enemigos que aparecerán en la oleada actual.
    public int enemigosPorOleada = 30;
    // Vida que tendrán los enemigos de la oleada actual.
    public int vidaEnemigosActual = 20;
    public int numeroDeOleadas = 5; // NUEVO: Límite de oleadas

    // Tiempo de descanso en segundos entre el final de una oleada y el comienzo de la siguiente.
    public float tiempoEntreOleadas = 5f;

    // Corutina que gestiona el spawner.
    private Coroutine spawnerCoroutine;

    void Start()
    {
        // Es una buena práctica verificar que las referencias asignadas en el editor no son nulas.
        if (enemigoPrefab == null)
        {
            Debug.LogError("El prefab del enemigo no está asignado en el Spawner.");
            return; // Detiene la ejecución si el prefab no está asignado.
        }
        // Inicia la corutina que gestiona las oleadas.
        spawnerCoroutine = StartCoroutine(GestionarOleadas());
    }

    IEnumerator GestionarOleadas()
    {
        // Bucle que se ejecuta hasta que se completen las 5 oleadas.
        while (oleadaActual <= numeroDeOleadas)
        {
            // NUEVO: Formateamos el texto para la UI y se lo enviamos al GameManager.
            string infoOleada = $"Oleada: {oleadaActual} / {numeroDeOleadas}\nEnemigos: {enemigosPorOleada}";
            GameManager.instance.ActualizarTextoOleada(infoOleada);

            Debug.Log("Iniciando Oleada: " + oleadaActual + " de " + numeroDeOleadas);

            // Bucle para generar los enemigos de la oleada actual.
            for (int i = 0; i < enemigosPorOleada; i++)
            {
                // Instancia un nuevo enemigo en la posición del Spawner.
                GameObject nuevoEnemigo = Instantiate(enemigoPrefab, transform.position, Quaternion.identity);
                GameManager.instance.RegistrarEnemigoGenerado(); // NUEVO: Notificamos al GameManager.

                // Obtiene el componente 'Enemy' del enemigo recién creado para establecer su vida.
                Enemy scriptEnemigo = nuevoEnemigo.GetComponent<Enemy>();
                if (scriptEnemigo != null)
                {
                    // Establece la vida del enemigo según la oleada actual.
                    scriptEnemigo.EstablecerVida(vidaEnemigosActual);
                }
                else
                {
                    Debug.LogWarning("El prefab del enemigo no tiene el script 'Enemy' adjunto.");
                }

                // Espera un tiempo antes de generar el siguiente enemigo.
                yield return new WaitForSeconds(tiempoEntreEnemigos);
            }

            // --- LA OLEADA HA TERMINADO DE APARECER ---

            // Si aún no hemos llegado a la última oleada, preparamos la siguiente.
            if (oleadaActual < numeroDeOleadas)
            {
                 // Prepara los valores para la siguiente oleada.
                oleadaActual++;
                enemigosPorOleada += 15;   // Incrementa en 15 la cantidad de enemigos para la próxima oleada.
                vidaEnemigosActual += 10;  // Aumenta en 10 la vida de los enemigos para la próxima oleada.

                Debug.Log("Oleada " + (oleadaActual - 1) + " finalizada. La siguiente oleada comenzará en " + tiempoEntreOleadas + " segundos.");

                // Espera un tiempo antes de empezar la siguiente oleada.
                yield return new WaitForSeconds(tiempoEntreOleadas);
            }
            else
            {
                // Si ya completamos la última oleada, simplemente salimos del bucle.
                oleadaActual++; 
            }
        }

        // --- TODAS LAS OLEADAS HAN TERMINADO ---
        Debug.Log("Todas las oleadas han sido generadas. El Spawner ha terminado.");
        GameManager.instance.SpawningCompleto(); // NUEVO: Notificamos al GameManager que hemos terminado.
    }

    /// <summary>
    /// Detiene la generación de enemigos.
    /// </summary>
    public void DetenerSpawner()
    {
        if (spawnerCoroutine != null)
        {
            StopCoroutine(spawnerCoroutine);
            Debug.Log("El Spawner ha sido detenido.");
        }
    }
}