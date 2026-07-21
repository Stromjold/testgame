using UnityEngine;

public class MenuInteractivo : MonoBehaviour
{
    [Header("Interfaz del Nodo")]
    public GameObject menuCanvas; // La ranura para tu menú de Canva (el perfil del soldado)

    void Start()
    {
        // Regla de inicio: El menú siempre debe estar oculto al empezar la partida
        if (menuCanvas != null)
        {
            menuCanvas.SetActive(false);
        }

        GameLogger.LogToFile("MenuInteractivo", "Menú interactivo inicializado. Canvas oculto al iniciar.");
    }

    // NUEVO: Esta función es pública para que el botón de Unity pueda llamarla
    public void AlternarMenu()
    {
        if (menuCanvas != null)
        {
            // Alternador (Toggle): Si está apagado lo prende, y si está prendido lo apaga
            bool estadoActual = menuCanvas.activeSelf;
            menuCanvas.SetActive(!estadoActual);
            GameLogger.LogToFile("MenuInteractivo", $"Menú interactivo alternado. Nuevo estado visible: {!estadoActual}");
        }
        else
        {
            GameLogger.LogToFile("MenuInteractivo", "[ADVERTENCIA] No se pudo alternar el menú porque menuCanvas es NULL.");
        }
    }
}