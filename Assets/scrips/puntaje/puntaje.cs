using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Recurso : MonoBehaviour
{
    public string nombreRecurso;
    public int cantidad = 1;
}

[System.Serializable]
public class RecursoEntry
{
    public string nombreRecurso;
    public int cantidad;
}

public class InventarioJugador : MonoBehaviour
{
    // Lista serializable para mostrar en el Inspector
    public List<RecursoEntry> recursosSerialized = new List<RecursoEntry>();

    // Diccionario usado en tiempo de ejecución (no serializable por Unity)
    private Dictionary<string, int> recursos = new Dictionary<string, int>();

    private void Awake()
    {
        // Reconstruir el diccionario a partir de la lista serializada al iniciar
        recursos.Clear();
        foreach (var e in recursosSerialized)
        {
            if (string.IsNullOrEmpty(e.nombreRecurso)) continue;
            if (recursos.ContainsKey(e.nombreRecurso)) recursos[e.nombreRecurso] += e.cantidad;
            else recursos[e.nombreRecurso] = e.cantidad;
        }
    }

    private void OnValidate()
    {
        // Mantener la lista y el diccionario sincronizados en el editor
        if (recursos == null) recursos = new Dictionary<string, int>();
        recursos.Clear();
        foreach (var e in recursosSerialized)
        {
            if (string.IsNullOrEmpty(e.nombreRecurso)) continue;
            if (recursos.ContainsKey(e.nombreRecurso)) recursos[e.nombreRecurso] += e.cantidad;
            else recursos[e.nombreRecurso] = e.cantidad;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Recurso recurso = other.GetComponent<Recurso>();

        if (recurso != null)
        {
            // Actualizar diccionario en tiempo de ejecución
            if (recursos.ContainsKey(recurso.nombreRecurso))
            {
                recursos[recurso.nombreRecurso] += recurso.cantidad;
            }
            else
            {
                recursos[recurso.nombreRecurso] = recurso.cantidad;
            }

            // Reflejar cambio en la lista serializada (para ver en Inspector)
            UpdateSerializedList();

            Debug.Log("Recogiste " + recurso.cantidad + " de " + recurso.nombreRecurso);
            Debug.Log("Total de " + recurso.nombreRecurso + ": " + recursos[recurso.nombreRecurso]);

            Destroy(other.gameObject);
        }
    }

    private void UpdateSerializedList()
    {
        recursosSerialized.Clear();
        foreach (var kv in recursos)
        {
            recursosSerialized.Add(new RecursoEntry { nombreRecurso = kv.Key, cantidad = kv.Value });
        }
    }
}

public class MenuVictoria : MonoBehaviour
{
    // Volver al menú principal
    public void MenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    // Reiniciar el nivel actual
    public void RepetirNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Salir del juego
    public void SalirJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}