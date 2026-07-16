using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Esta estructura crea las casillas en el Inspector de Unity
    [System.Serializable]
    public struct DatosOleada
    {
        public string nombreDeOleada;
        public GameObject enemigoPrefab; // Aquí arrastrarás al monstruo que quieras
        public int cantidadDeEnemigos;
        public int vidaEnemigos;
        public float tiempoEntreEnemigos;
    }

    [Header("Configuración de Oleadas")]
    public DatosOleada[] listaDeOleadas; 
    public float tiempoEntreOleadas = 5f; //   

    private int oleadaActualIndex = 0;
    private Coroutine spawnerCoroutine;

    void Start()
    {
        if (listaDeOleadas == null || listaDeOleadas.Length == 0)
        {
            Debug.LogError("No has configurado ninguna oleada en el Spawner.");
            return;
        }

        spawnerCoroutine = StartCoroutine(GestionarOleadas());
    }

    IEnumerator GestionarOleadas()
    {
        while (oleadaActualIndex < listaDeOleadas.Length)
        {
            DatosOleada datos = listaDeOleadas[oleadaActualIndex];

            // 1. Actualizamos la UI del GameManager
            string infoOleada = $"Oleada: {oleadaActualIndex + 1} / {listaDeOleadas.Length}\nEnemigos: {datos.cantidadDeEnemigos}";
            if(GameManager.instance != null) GameManager.instance.ActualizarTextoOleada(infoOleada);

            // 2. Generamos los monstruos elegidos para esta oleada
            for (int i = 0; i < datos.cantidadDeEnemigos; i++)
            {
                if (datos.enemigoPrefab == null)
                {
                    Debug.LogError("Falta asignar el prefab del enemigo en la oleada " + (oleadaActualIndex + 1));
                    yield break;
                }

                // Genera el monstruo en el punto de inicio
                GameObject nuevoEnemigo = Instantiate(datos.enemigoPrefab, transform.position, Quaternion.identity);
                if(GameManager.instance != null) GameManager.instance.RegistrarEnemigoGenerado();

                // Le asignamos la vida configurada en el Inspector
                Enemy scriptEnemigo = nuevoEnemigo.GetComponent<Enemy>();
                if (scriptEnemigo != null)
                {
                    scriptEnemigo.EstablecerVida(datos.vidaEnemigos);
                }

                yield return new WaitForSeconds(datos.tiempoEntreEnemigos);
            }

            // --- LA OLEADA HA TERMINADO ---
            oleadaActualIndex++;

            if (oleadaActualIndex < listaDeOleadas.Length)
            {
                yield return new WaitForSeconds(tiempoEntreOleadas);
            }
        }

        // --- TODAS LAS OLEADAS COMPLETADAS ---
        if(GameManager.instance != null) GameManager.instance.SpawningCompleto();
    }

    public void DetenerSpawner()
    {
        if (spawnerCoroutine != null)
        {
            StopCoroutine(spawnerCoroutine);
        }
    }
}