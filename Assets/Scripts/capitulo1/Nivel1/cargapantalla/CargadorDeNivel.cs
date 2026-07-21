using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
using TMPro; // Necesario para tu texto de porcentaje

public class CargadorDeNivel : MonoBehaviour
{
    [Header("Configuración del Destino")]
    [Tooltip("Pon el número de tu escena según el Build Profiles (Ej: 2 para Nivel_1_1)")]
    public int indiceEscena = 2; // Ahora usamos un número (int) en lugar de texto
    
    [Header("Conexiones Visuales")]
    public Image barraDeCargaUI;
    public TextMeshProUGUI textoPorcentajeUI; 

    void Start()
    {
        if (barraDeCargaUI != null) barraDeCargaUI.fillAmount = 0f;
        GameLogger.LogToFile("CargadorDeNivel", $"Carga de nivel iniciada. Índice de escena destino: {indiceEscena}");
        StartCoroutine(CargarEscenaAsincrona());
    }

    IEnumerator CargarEscenaAsincrona()
    {
        // Carga la escena usando su número de ID
        AsyncOperation operacion = SceneManager.LoadSceneAsync(indiceEscena);

        while (!operacion.isDone)
        {
            float progreso = Mathf.Clamp01(operacion.progress / 0.9f);
            
            if (barraDeCargaUI != null) 
            {
                barraDeCargaUI.fillAmount = progreso;
            }

            // Actualiza el texto con el porcentaje (Ej: "50%")
            if (textoPorcentajeUI != null) 
            {
                textoPorcentajeUI.text = Mathf.RoundToInt(progreso * 100f) + "%";
            }

            yield return null; 
        }

        GameLogger.LogToFile("CargadorDeNivel", $"Carga de nivel completada. Índice de escena destino: {indiceEscena}");
    }
}