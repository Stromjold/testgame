using UnityEngine;
using TMPro; 
using UnityEngine.UI; // NUEVO: Librería para controlar imágenes y barras

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 

    [Header("Reglas del Nivel")]
    public int enemigosEliminados = 0;
    public int metaEnemigos = 150; 

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

    [Header("Barra de Progreso")]
    public Image barraProgreso; // NUEVO: La ranura para tu barra verde

    void Awake()
    {
        instance = this; 
    }

    void Start()
    {
        // Forzamos a que la barra empiece vacía (0%) al iniciar el juego
        if (barraProgreso != null) barraProgreso.fillAmount = 0f; 
        ActualizarPantalla(); 
    }

    public void RegistrarMuerte()
    {
        enemigosEliminados++;
        
        // ¡REGLA ACTUALIZADA! Ahora suma exactamente 2 puntos por baja
        puntos += 2; 

        // NUEVO: Matemática para calcular el porcentaje de la barra (de 0.0 a 1.0)
        if (barraProgreso != null)
        {
            barraProgreso.fillAmount = (float)enemigosEliminados / metaEnemigos;
        }

        ActualizarPantalla();

        if (enemigosEliminados >= metaEnemigos)
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
    }

    void DeclararVictoria()
    {
        Debug.Log("¡VICTORIA! El puerto está limpio.");
    }
}