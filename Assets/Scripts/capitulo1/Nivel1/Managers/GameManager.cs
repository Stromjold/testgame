using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Reglas del Nivel")]
    public int enemigosEliminados = 0;
    public int metaEnemigos = 150;
    public int enemigosVivos = 0;
    private bool spawningTerminado = false;

    [Header("Inventario y Puntuación")]
    public int cristales = 0;
    public int artefactos = 0;
    public int materiaOscura = 0;
    public int orbes = 0;
    public int puntos = 0;

    [Header("Textos de UI (Contadores)")]
    public TextMeshProUGUI textoCristales;
    public TextMeshProUGUI textoArtefactos;
    public TextMeshProUGUI textoMateriaOscura;
    public TextMeshProUGUI textoOrbes;
    public TextMeshProUGUI textoPuntos;

    [Header("Interfaz de Textos (UI)")]
    public TextMeshProUGUI textoInfoOleada; 

    [Header("Barra de Progreso (Enemigos)")]
    public Image barraProgreso;

    [Header("--- BARRA DE SALUD GLOBAL DEL ESCUADRÓN ---")]
    public Image barraVerdeSalud;

    [Header("--- PANTALLAS DE FIN DE JUEGO ---")]
    public GameObject pantallaVictoria;
    public GameObject panelDerrota;

    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }

    void Start()
    {
        if (barraProgreso != null) barraProgreso.fillAmount = 0f;
        if (barraVerdeSalud != null) barraVerdeSalud.fillAmount = 1f;

        ActualizarTextosUI();

        GameLogger.LogToFile("GameManager", $"GameManager inicializado. Meta enemigos: {metaEnemigos} (Sistema de mejoras deshabilitado, centrado en Armería).");

        if (pantallaVictoria != null) pantallaVictoria.SetActive(false);
        if (panelDerrota != null) panelDerrota.SetActive(false);
    }

    public void RegistrarMuerte()
    {
        enemigosEliminados++;
        enemigosVivos--;
        puntos += 2; // Suma de puntos por baja de enemigo
        
        if (barraProgreso != null) barraProgreso.fillAmount = (float)enemigosEliminados / metaEnemigos;
        
        ActualizarTextosUI();
        GameLogger.LogToFile("GameManager", $"Enemigo eliminado. Eliminados: {enemigosEliminados} | Vivos: {enemigosVivos} | Puntos: {puntos}");
        CheckForWin();
    }

    public void RegistrarEnemigoGenerado() 
    { 
        enemigosVivos++; 
        ActualizarTextosUI();
    }

    public void SpawningCompleto()
    {
        spawningTerminado = true;
        ActualizarTextoOleada("¡Todas las oleadas completadas!"); 
        GameLogger.LogToFile("GameManager", "Todas las oleadas completadas. Se evalúa condición de victoria.");
        CheckForWin();
    }

    public void ActualizarTextoOleada(string texto)
    {
        if (textoInfoOleada != null) textoInfoOleada.text = texto;
    }

    private void CheckForWin() 
    { 
        if (spawningTerminado && enemigosVivos <= 0) 
        {
            if (pantallaVictoria != null) pantallaVictoria.SetActive(true);
            Time.timeScale = 0f;
        } 
    }

    public void ActualizarBarraDeVidaGlobal(float porcentaje)
    {
        if (barraVerdeSalud != null) barraVerdeSalud.fillAmount = porcentaje;

        if (porcentaje <= 0f)
        {
            GatilloDerrota();
        }
    }

    private void GatilloDerrota()
    {
        GameLogger.LogToFile("GameManager", "[DERROTA] La salud global del escuadrón llegó a 0.");
        if (panelDerrota != null)
        {
            panelDerrota.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        
        ActualizarTextosUI();
        GameLogger.LogToFile("GameManager", $"Recurso recogido: {tipoRecurso} x{cantidad}. Cristales={cristales}, Artefactos={artefactos}");
    }

    void ActualizarTextosUI()
    {
        if (textoCristales != null) textoCristales.text = cristales.ToString();
        if (textoArtefactos != null) textoArtefactos.text = artefactos.ToString();
        if (textoMateriaOscura != null) textoMateriaOscura.text = materiaOscura.ToString();
        if (textoOrbes != null) textoOrbes.text = orbes.ToString();
        if (textoPuntos != null) textoPuntos.text = puntos.ToString();
    }

    public void BotonMenuPrincipal()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MenuPrincipal"); 
    }

    public void BotonRepetirNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void BotonContinuar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Nivel_1_2"); 
    }
}