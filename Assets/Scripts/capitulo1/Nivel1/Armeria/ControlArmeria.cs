using UnityEngine;

public class ControlArmeria : MonoBehaviour
{
    [Header("Panel Visual de la Armería")]
    [Tooltip("Arrastra aquí el panel o imagen gigante que contiene tu armería")]
    public GameObject panelArmeria;

    [Header("Configuración")]
    [Tooltip("¿Quieres que el juego se pause mientras miras las armas?")]
    public bool pausarJuegoAlAbrir = true;

    void Start()
    {
        // Nos aseguramos de que la armería empiece cerrada cuando arranca el nivel
        if (panelArmeria != null)
        {
            panelArmeria.SetActive(false);
        }
    }

    // Esta es la función que conectaremos a tu botón
    public void AlternarArmeria()
    {
        if (panelArmeria != null)
        {
            // Revisa si la armería está prendida o apagada, y hace lo contrario
            bool estadoActual = panelArmeria.activeSelf;
            bool nuevoEstado = !estadoActual;
            
            // Prende o apaga el panel visual
            panelArmeria.SetActive(nuevoEstado);

            // Congela el tiempo si abrimos, o lo reanuda si cerramos
            if (pausarJuegoAlAbrir)
            {
                Time.timeScale = nuevoEstado ? 0f : 1f;
            }
        }
    }
}