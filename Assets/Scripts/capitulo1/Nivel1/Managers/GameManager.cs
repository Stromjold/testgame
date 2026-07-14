using UnityEngine;
using TMPro; 
using UnityEngine.UI;

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

    [Header("Interfaz de Textos (UI)")]
    public TextMeshProUGUI textoCristales;
    public TextMeshProUGUI textoArtefactos;
    public TextMeshProUGUI textoOscura;
    public TextMeshProUGUI textoOrbes;
    public TextMeshProUGUI textoPuntos;
    public TextMeshProUGUI textoEnemigosEliminados; // NUEVO: Para mostrar el total de enemigos eliminados
    public TextMeshProUGUI textoInfoOleada; // NUEVO: Para mostrar la info de la oleada actual

    [Header("Barra de Progreso")]
    public Image barraProgreso; 

    void Awake()
    {
        instance = this; 
    }

    void Start()
    {
        if (barraProgreso != null) barraProgreso.fillAmount = 0f; 
        ActualizarPantalla(); 
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

    // NUEVO: El Spawner llamará a este método para actualizar la información de la oleada en la UI.
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
    }

    void ActualizarPantalla()
    {
        if (textoCristales != null) textoCristales.text = cristales.ToString();
        if (textoArtefactos != null) textoArtefactos.text = artefactos.ToString();
        if (textoOscura != null) textoOscura.text = materiaOscura.ToString();
        if (textoOrbes != null) textoOrbes.text = orbes.ToString();
        if (textoPuntos != null) textoPuntos.text = puntos.ToString();

        // NUEVO: Actualizamos el texto de enemigos eliminados
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