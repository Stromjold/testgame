using UnityEngine;

public class RecursoDrop : MonoBehaviour
{
    [Header("Configuración del Objeto")]
    [Tooltip("Escribe exactamente: Cristal, Artefacto, Oscura o Orbe")]
    public string tipoDeRecurso = "Cristal";
    public int cantidad = 1;

    /// <summary>
    /// Esta función nativa de Unity se ejecuta automáticamente cuando el jugador
    /// hace clic izquierdo con el mouse sobre el Collider 2D de este objeto.
    /// </summary>
    private void OnMouseDown()
    {
        if (GameManager.instance != null)
        {
            // 1. Le avisamos al GameManager que sume los puntos (esto actualizará la tabla de tu segunda foto)
            GameManager.instance.RecogerRecurso(tipoDeRecurso, cantidad);

            // 2. Destruimos el objeto del suelo para que desaparezca
            Destroy(gameObject);
        }
    }
}