using UnityEngine;
using UnityEngine.UI;

public class BotonMejora : MonoBehaviour
{
    private Button miBoton;

    private void Awake()
    {
        // Obtenemos el componente Button del propio GameObject
        miBoton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        // Nos suscribimos al evento del clic del botón
        if (miBoton != null)
        {
            miBoton.onClick.AddListener(IntentarMejorar);
        }
    }

    private void OnDisable()
    {
        // Desuscribirse al desactivar el botón para evitar errores de memoria
        if (miBoton != null)
        {
            miBoton.onClick.RemoveListener(IntentarMejorar);
        }
    }

    private void IntentarMejorar()
    {
        // Nos conectamos con el GameManager utilizando la variable 'instance' corregida
        if (GameManager.instance != null)
        {
            GameManager.instance.ComprarMejoraSoldados();
        }
        else
        {
            Debug.LogError("No se encontró el GameManager en la escena.");
        }
    }
}