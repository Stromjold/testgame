using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;

    void Awake()
    {
        // Cuenta cuántos puntos hijos tiene la ruta
        points = new Transform[transform.childCount];
        
        // Guarda cada punto en el arreglo
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}