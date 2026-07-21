using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public class ComponenteDrop
    {
        public string nombreComponente = "Cristal";
        public GameObject prefabObjeto; // El prefab físico que caerá al suelo
    }

    [System.Serializable]
    public class TipoEnemigo
    {
        public string nombreMonstruo = "Zombie Base";
        public GameObject prefabEnemigo;
        public int vidaInicial = 10;

        [Header("Componentes que puede botar (Check)")]
        // Lista de booleanos alineada con la sección general de componentes
        public List<bool> componentesPermitidos = new List<bool>();
    }

    [Header("--- 1. SECCIÓN DE COMPONENTES ---")]
    public List<ComponenteDrop> catalogoComponentes = new List<ComponenteDrop>();

    [Header("--- 2. CATÁLOGO DE MONSTRUOS ---")]
    public List<TipoEnemigo> catalogoMonstruos = new List<TipoEnemigo>();

    [Header("Configuración de Oleadas")]
    public float tiempoEntreOleadas = 5f;
    public int enemigosPorOleada = 40;
    
    [Header("Ritmo de Aparición")]
    public float tiempoEntreEnemigos = 3f; 

    private int oleadaActual = 1;
    private int totalOleadas = 5;

    void Start()
    {
        GameLogger.LogToFile("Spawner", $"Spawner inicializado. Componentes: {catalogoComponentes.Count} | Monstruos: {catalogoMonstruos.Count}");
        
        if (catalogoMonstruos.Count > 0)
        {
            StartCoroutine(GestionarOleadas());
        }
        else
        {
            Debug.LogError("[❌ ERROR SPAWNER] El catálogo de monstruos está vacío en el Inspector.");
        }
    }

    IEnumerator GestionarOleadas()
    {
        GameLogger.LogToFile("Spawner", $"Iniciando oleada {oleadaActual}/{totalOleadas}. Total de enemigos a generar: {enemigosPorOleada}");

        for (int i = 0; i < enemigosPorOleada; i++)
        {
            SpawnetearMonstruoAleatorio();
            
            yield return new WaitForSeconds(tiempoEntreEnemigos); 
        }
    }

    void SpawnetearMonstruoAleatorio()
    {
        if (catalogoMonstruos.Count == 0) return;

        int indexAleatorio = Random.Range(0, catalogoMonstruos.Count);
        TipoEnemigo seleccionado = catalogoMonstruos[indexAleatorio];

        if (seleccionado.prefabEnemigo != null)
        {
            GameObject enemigoGO = Instantiate(seleccionado.prefabEnemigo);
            
            Zombiee zombieScript = enemigoGO.GetComponent<Zombiee>();
            if (zombieScript != null)
            {
                zombieScript.EstablecerVida(seleccionado.vidaInicial);

                // Seleccionar un componente al azar entre los que tengan el Check (true) activado para este monstruo
                GameObject dropElegido = ObtenerDropPermitidoAleatorio(seleccionado);
                if (dropElegido != null)
                {
                    zombieScript.prefabRecursoDrop = dropElegido;
                }
            }

            GameLogger.LogToFile("Spawner", $"Monstruo '{seleccionado.nombreMonstruo}' instanciado con éxito.");
        }
    }

    GameObject ObtenerDropPermitidoAleatorio(TipoEnemigo monstruo)
    {
        List<GameObject> dropsDisponibles = new List<GameObject>();

        for (int i = 0; i < monstruo.componentesPermitidos.Count && i < catalogoComponentes.Count; i++)
        {
            if (monstruo.componentesPermitidos[i] && catalogoComponentes[i].prefabObjeto != null)
            {
                dropsDisponibles.Add(catalogoComponentes[i].prefabObjeto);
            }
        }

        if (dropsDisponibles.Count > 0)
        {
            int index = Random.Range(0, dropsDisponibles.Count);
            return dropsDisponibles[index];
        }

        return null; 
    }
}