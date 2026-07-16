using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Botón Jugar
    public void Jugar()
    {
        SceneManager.LoadScene("Capitulo1");
    }

    // Botón Salir
    public void Salir()
    {
        Debug.Log("Cerrando juego...");
        Application.Quit();
    }
}