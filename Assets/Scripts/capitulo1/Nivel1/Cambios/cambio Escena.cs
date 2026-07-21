using UnityEngine;
using UnityEngine.SceneManagement; // Requisito obligatorio para cambiar de escena

public class MenuManager : MonoBehaviour
{
    // Este método debe ser público para que el botón de la UI pueda verlo
    public void IniciarJuego()
    {
        // Carga la escena del juego usando su nombre exacto entre comillas
        GameLogger.LogToFile("MenuManager", "[MENÚ PRINCIPAL] Iniciando juego, cargando escena: nivel_1_1");
        SceneManager.LoadScene("nivel_1_1");
    }
}
