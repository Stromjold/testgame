using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject panelPausa;

    private bool juegoPausado = false;

    void Start()
    {
        if (panelPausa != null) panelPausa.SetActive(false);
        GameLogger.LogToFile("MenuPausa", "Sistema de pausa inicializado. Panel desactivado por defecto.");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Continuar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Pausar()
    {
        if (panelPausa != null) panelPausa.SetActive(true);
        Time.timeScale = 0f;
        juegoPausado = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        GameLogger.LogToFile("MenuPausa", "[PAUSA] El juego ha sido pausado. TimeScale: 0");
    }

    public void Continuar()
    {
        if (panelPausa != null) panelPausa.SetActive(false);
        Time.timeScale = 1f;
        juegoPausado = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        GameLogger.LogToFile("MenuPausa", "[REANUDAR] El juego continúa. TimeScale: 1");
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        GameLogger.LogToFile("MenuPausa", "[REINICIAR] Reiniciando escena actual (Build Index: " + SceneManager.GetActiveScene().buildIndex + ")");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Salir()
    {
        Time.timeScale = 1f;
        GameLogger.LogToFile("MenuPausa", "[SALIR] Saliendo al menú principal (MenuPrincipal).");
        SceneManager.LoadScene("MenuPrincipal");
    }
}