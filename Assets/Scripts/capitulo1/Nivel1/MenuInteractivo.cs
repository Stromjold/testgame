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
    }

    // NUEVO: Esta función es pública para que el botón de Unity pueda llamarla
    public void AlternarMenu()
    {
        if (menuCanvas != null)
        {
            // Alternador (Toggle): Si está apagado lo prende, y si está prendido lo apaga
            bool estadoActual = menuCanvas.activeSelf;
            menuCanvas.SetActive(!estadoActual);
        }
    }
}