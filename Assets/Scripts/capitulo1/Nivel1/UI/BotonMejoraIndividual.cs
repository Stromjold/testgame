using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BotonMejoraIndividual : MonoBehaviour
{
    public enum TipoMejora { Vida, Danio }

    [Header("Configuración")]
    public TipoMejora tipoDeMejora;
    public int costoInicial = 30;

    [Header("UI del Botón")]
    public TextMeshProUGUI textoCosto;
    private Button miBoton;
    private int costoActual;

    private void Start()
    {
        miBoton = GetComponent<Button>();
        costoActual = costoInicial;
        ActualizarBotonUI();

        if (miBoton != null)
        {
            miBoton.onClick.AddListener(IntentarComprar);
        }
    }

    private void Update()
    {
        // Desactiva el botón automáticamente si no hay suficientes cristales en la tabla
        if (GameManager.instance != null && miBoton != null)
        {
            miBoton.interactable = (GameManager.instance.cristales >= costoActual);
        }
    }

    public void IntentarComprar()
    {
        if (GameManager.instance != null && GameManager.instance.cristales >= costoActual)
        {
            // Restamos los cristales usando el sistema del GameManager
            GameManager.instance.cristales -= costoActual;

            // Aplicamos la mejora a cada soldado activo en el mapa
            foreach (Soldier soldado in GameManager.instance.soldadosActivos)
            {
                if (soldado != null)
                {
                    if (tipoDeMejora == TipoMejora.Vida)
                    {
                        // Ejemplo: soldado.AumentarVidaMaxima(20);
                        Debug.Log("Mejorando vida de un soldado activo.");
                    }
                    else if (tipoDeMejora == TipoMejora.Danio)
                    {
                        // Ejemplo: soldado.AumentarDanio(5);
                        Debug.Log("Mejorando daño de un soldado activo.");
                    }
                }
            }

            // Escalamos el costo del botón para el siguiente nivel
            costoActual = Mathf.RoundToInt(costoActual * 1.5f);

            // Forzamos al GameManager a refrescar la UI global de recursos
            GameManager.instance.RecogerRecurso("Cristal", 0);
            ActualizarBotonUI();
        }
    }

    private void ActualizarBotonUI()
    {
        if (textoCosto != null)
        {
            textoCosto.text = "Costo: " + costoActual;
        }
    }
}