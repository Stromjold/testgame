using UnityEngine;

public class Waypoints : MonoBehaviour
{
    // Ahora guardaremos una lista de las RUTAS (Pasaje1, Pasaje2, etc.)
    public static Transform[] rutas;

    void Awake()
    {
        // Contamos cuántos Pasajes (hijos) tiene RutaEnemigos
        rutas = new Transform[transform.childCount];
        
        for (int i = 0; i < rutas.Length; i++)
        {
            rutas[i] = transform.GetChild(i);
        }

        GameLogger.LogToFile("Waypoints", $"Waypoints inicializado. Rutas disponibles: {rutas.Length}");
    }
}