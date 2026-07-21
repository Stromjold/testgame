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

        GameLogger.LogToFile("BotonMejoraIndividual", $"Botón de mejora individual inicializado. Tipo: {tipoDeMejora} | Costo inicial: {costoInicial}");

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
            GameLogger.LogToFile("BotonMejoraIndividual", $"Compra aceptada. Tipo: {tipoDeMejora} | Costo pagado: {costoActual} | Cristales restantes: {GameManager.instance.cristales}");

            // NUEVO: Aplicamos la mejora comunicándonos con el Controlador Maestro
            if (ControlSoldados.instance != null)
            {
                foreach (ControlSoldados.Soldado soldado in ControlSoldados.instance.escuadron)
                {
                    if (soldado != null)
                    {
                        if (tipoDeMejora == TipoMejora.Vida)
                        {
                            // Aquí irá tu lógica futura para la vida
                            Debug.Log("Mejorando vida del escuadrón.");
                        }
                        else if (tipoDeMejora == TipoMejora.Danio)
                        {
                            // Aquí irá tu lógica futura para el daño
                            Debug.Log("Mejorando daño del escuadrón.");
                        }
                    }
                }
            }

            // Escalamos el costo del botón para el siguiente nivel
            costoActual = Mathf.RoundToInt(costoActual * 1.5f);

            // Forzamos al GameManager a refrescar la UI global de recursos
            GameManager.instance.RecogerRecurso("Cristal", 0);
            ActualizarBotonUI();
        }
        else
        {
            GameLogger.LogToFile("BotonMejoraIndividual", $"[FALLO DE COMPRA] Tipo: {tipoDeMejora} | Costo: {costoActual} | Cristales disponibles: {(GameManager.instance != null ? GameManager.instance.cristales : 0)}");
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