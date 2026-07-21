using UnityEngine;using UnityEngine.SceneManagement;public class MenuInicio : MonoBehaviour

{

public void IniciarJuego()

{

// Usamos el número 1, que corresponde a tu pantalla de carga en el Build Profiles

GameLogger.LogToFile("MenuInicio", "[INICIO] Iniciando juego por índice de escena: 1");

SceneManager.LoadScene(1);

}

} 

