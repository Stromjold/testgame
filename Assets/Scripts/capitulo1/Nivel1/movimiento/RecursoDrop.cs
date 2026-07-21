using UnityEngine;

public class RecursoDrop : MonoBehaviour
{
    [Header("Configuración del Recurso")]
    public string tipoDeRecurso = "Cristal"; // "Cristal", "Artefacto", "Oscura", "Orbe"
    public int cantidad = 1;
    public float tiempoParaAutoRecogida = 3f; // Se recogen solos a los 3 segundos

    [Header("Tiempo de Vida")]
    public float tiempoDesaparicion = 2f;

    void Start()
    {
        // Programamos la recogida automática tras 3 segundos
        Invoke("AutoRecoger", tiempoParaAutoRecogida);
        GameLogger.LogToFile("RecursoDrop", $"[SPAWN] Tipo: {tipoDeRecurso} | Cantidad: {cantidad} | Posición: {transform.position}");
    }

    void AutoRecoger()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.RecogerRecurso(tipoDeRecurso, cantidad);
            GameLogger.LogToFile("RecursoDrop", $"[AUTO-RECOGIDO] El recurso '{tipoDeRecurso}' x{cantidad} fue recogido automáticamente tras 3 segundos.");
        }
        Destroy(gameObject);
    }

    void OnMouseDown()
    {
        AutoRecoger();
    }
}