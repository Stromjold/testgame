using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic; // Necesario para la lista de soldados activos

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Reglas del Nivel")]
    public int enemigosEliminados = 0;
    public int metaEnemigos = 150;
    public int enemigosVivos = 0;
    private bool spawningTerminado = false;

    [Header("Inventario")]
    public int cristales = 0;
    public int artefactos = 0;
    public int materiaOscura = 0;
    public int orbes = 0;
    public int puntos = 0;

    [Header("Sistema de Mejoras Globales")]
    public int nivelSoldados = 1;               // El nivel actual de todos los soldados
    public int costoMejoraSoldado = 50;         // Cuánto cuesta mejorar
    public TextMeshProUGUI textoCostoMejora;   // Arrastra aquí el texto de costo de tu pestaña de mejoras
    public Button botonMejorar;                // Arrastra aquí el botón de "Mejorar" de tu pestaña

    // Lista automática para saber qué soldados están colocados en el mapa
    [HideInInspector]
    public List<Soldier> soldadosActivos = new List<Soldier>();

    [Header("Interfaz de Textos (UI)")]
    public TextMeshProUGUI textoCristales;
    public TextMeshProUGUI textoArtefactos;
    public TextMeshProUGUI textoOscura;
    public TextMeshProUGUI textoOrbes;
    public TextMeshProUGUI textoPuntos;
    public TextMeshProUGUI textoEnemigosEliminados;
    public TextMeshProUGUI textoInfoOleada;

    [Header("Barra de Progreso")]
    public Image barraProgreso;

    void Awake()
    {
        // Singleton seguro: evita duplicados al recargar la escena
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (barraProgreso != null) barraProgreso.fillAmount = 0f;
        ActualizarPantalla();
        ActualizarInterfazMejora();
    }

    // --- Ejecuta la mejora de todos los soldados ---
    public void ComprarMejoraSoldados()
    {
        // Comprobamos si el jugador tiene suficientes cristales
        if (cristales >= costoMejoraSoldado)
        {
            cristales -= costoMejoraSoldado; // Restamos el costo
            nivelSoldados++;                 // Subimos de nivel global
            costoMejoraSoldado = Mathf.RoundToInt(costoMejoraSoldado * 1.8f); // Aumentamos el costo para la siguiente

            // Le avisamos a todos los soldados que ya están en el mapa que actualicen sus estadísticas
            foreach (Soldier soldado in soldadosActivos)
            {
                if (soldado != null)
                {
                    soldado.ActualizarEstadisticasPorNivel();
                }
            }

            ActualizarPantalla();
            ActualizarInterfazMejora();
            Debug.Log("¡Soldados mejorados al nivel " + nivelSoldados + "!");
        }
        else
        {
            Debug.Log("¡No tienes suficientes cristales!");
        }
    }

    // --- Muestra el costo y bloquea el botón si no te alcanza ---
    public void ActualizarInterfazMejora()
    {
        if (textoCostoMejora != null)
        {
            textoCostoMejora.text = "Costo: " + costoMejoraSoldado + " Cristales";
        }

        if (botonMejorar != null)
        {
            // El botón se desactivará solo si no tienes suficientes cristales
            botonMejorar.interactable = (cristales >= costoMejoraSoldado);
        }
    }

    public void RegistrarMuerte()
    {
        enemigosEliminados++;
        enemigosVivos--;

        puntos += 2;

        if (barraProgreso != null)
        {
            barraProgreso.fillAmount = (float)enemigosEliminados / metaEnemigos;
        }

        ActualizarPantalla();
        CheckForWin();
    }

    public void RegistrarEnemigoGenerado()
    {
        enemigosVivos++;
    }

    public void SpawningCompleto()
    {
        spawningTerminado = true;
        Debug.Log("GameManager: El Spawner ha terminado. Comprobando condición de victoria...");
        ActualizarTextoOleada("¡Todas las oleadas completadas!");
        CheckForWin();
    }

    public void ActualizarTextoOleada(string texto)
    {
        if (textoInfoOleada != null)
        {
            textoInfoOleada.text = texto;
        }
    }

    private void CheckForWin()
    {
        if (spawningTerminado && enemigosVivos <= 0)
        {
            DeclararVictoria();
        }
    }

    public void RecogerRecurso(string tipoRecurso, int cantidad)
    {
        switch (tipoRecurso)
        {
            case "Cristal": cristales += cantidad; break;
            case "Artefacto": artefactos += cantidad; break;
            case "Oscura": materiaOscura += cantidad; break;
            case "Orbe": orbes += cantidad; break;
        }
        ActualizarPantalla();
        ActualizarInterfazMejora(); // Actualizamos si el botón debe prenderse o apagarse
    }

    void ActualizarPantalla()
    {
        if (textoCristales != null) textoCristales.text = cristales.ToString();
        if (textoArtefactos != null) textoArtefactos.text = artefactos.ToString();
        if (textoOscura != null) textoOscura.text = materiaOscura.ToString();
        if (textoOrbes != null) textoOrbes.text = orbes.ToString();
        if (textoPuntos != null) textoPuntos.text = puntos.ToString();

        if (textoEnemigosEliminados != null)
        {
            textoEnemigosEliminados.text = "Eliminados: " + enemigosEliminados;
        }
    }

    void DeclararVictoria()
    {
        Debug.Log("¡VICTORIA! ¡Has sobrevivido a las 5 oleadas!");
        ActualizarTextoOleada("¡VICTORIA!");
    }
}