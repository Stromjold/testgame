using UnityEngine;

public class RecursoDrop : MonoBehaviour
{
    [Header("Configuración del Objeto")]
    [Tooltip("Escribe exactamente: Cristal, Artefacto, Oscura o Orbe")]
    public string tipoDeRecurso = "Cristal"; 
    public int cantidad = 1;

    // Esta función se activa cuando otro objeto entra en la zona del BoxCollider (Is Trigger)
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Revisamos si el objeto que lo tocó tiene la etiqueta "Player" (tu soldado)
        if (collision.CompareTag("Player")) 
        {
            // Le avisamos al GameManager central que sume los puntos
            GameManager.instance.RecogerRecurso(tipoDeRecurso, cantidad);
            
            // Destruimos el objeto del suelo (desaparece visualmente)
            Destroy(gameObject);
        }
    }
}