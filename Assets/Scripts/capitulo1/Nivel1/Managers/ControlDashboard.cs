using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlDashboard : MonoBehaviour
{
    // --- ESTRUCTURA DE RECURSOS ---
    [System.Serializable]
    public class PanelRecurso
    {
        public string nombre = "Recurso";

        [Header("Control Visual (Magia en tiempo real)")]
        public Sprite icono; 
        public Image imagenUI; 

        [Header("Control de Texto")]
        public TextMeshProUGUI textoUI; 
    }

    // --- NUEVO: ESTRUCTURA DE LA BARRA DE VIDA ---
    [System.Serializable]
    public class BarraEquipo
    {
        [Header("Control Visual")]
        [Tooltip("Arrastra aquí el objeto 'Img_BarraProgreso'")]
        public Image barraUI;
        [Tooltip("Cambia el color de la barra desde aquí")]
        public Color colorBarra = Color.green;

        [Header("Control de Texto")]
        [Tooltip("Arrastra aquí el objeto 'Txt_Barra'")]
        public TextMeshProUGUI textoBarraUI;
        [Tooltip("Si está marcado, calculará el porcentaje automático (Ej: 100%). Si no, usará el texto de abajo.")]
        public bool mostrarComoPorcentaje = true;
        [Tooltip("Escribe aquí el texto si NO quieres usar el porcentaje")]
        public string textoManual = "Vida Base";
    }

    [Header("--- SECCIONES DEL DASHBOARD ---")]
    public PanelRecurso cristales;
    public PanelRecurso artefactos;
    public PanelRecurso materiaOscura;
    public PanelRecurso orbes;
    public PanelRecurso puntos;

    [Header("--- BARRA DE VIDA DE EQUIPO ---")]
    public BarraEquipo barraDeVida;

    // Magia: Se ejecuta al hacer cambios en el Inspector sin darle a Play
    void OnValidate()
    {
        ActualizarDibujo(cristales);
        ActualizarDibujo(artefactos);
        ActualizarDibujo(materiaOscura);
        ActualizarDibujo(orbes);
        ActualizarDibujo(puntos);

        ActualizarBarraEnEditor();
    }

    private void ActualizarDibujo(PanelRecurso recurso)
    {
        if (recurso != null && recurso.imagenUI != null && recurso.icono != null)
        {
            recurso.imagenUI.sprite = recurso.icono;
        }
    }

    // NUEVO: Función para actualizar el color y texto de la barra en el Editor
    private void ActualizarBarraEnEditor()
    {
        if (barraDeVida == null) return;

        // Cambiar color en tiempo real
        if (barraDeVida.barraUI != null)
        {
            barraDeVida.barraUI.color = barraDeVida.colorBarra;
        }

        // Cambiar texto en tiempo real
        if (barraDeVida.textoBarraUI != null)
        {
            if (barraDeVida.mostrarComoPorcentaje)
            {
                // En el editor, simulamos que está al 100%
                barraDeVida.textoBarraUI.text = "100%";
            }
            else
            {
                barraDeVida.textoBarraUI.text = barraDeVida.textoManual;
            }
        }
    }

    // Se ejecuta todo el tiempo durante el juego
    void Update()
    {
        if (GameManager.instance != null)
        {
            if (cristales.textoUI != null) cristales.textoUI.text = GameManager.instance.cristales.ToString();
            if (artefactos.textoUI != null) artefactos.textoUI.text = GameManager.instance.artefactos.ToString();
            if (materiaOscura.textoUI != null) materiaOscura.textoUI.text = GameManager.instance.materiaOscura.ToString();
            if (orbes.textoUI != null) orbes.textoUI.text = GameManager.instance.orbes.ToString();
            if (puntos.textoUI != null) puntos.textoUI.text = GameManager.instance.puntos.ToString();
        }

        // NUEVO: Sincroniza el porcentaje exacto de la barra durante el juego
        if (barraDeVida != null && barraDeVida.barraUI != null && barraDeVida.textoBarraUI != null)
        {
            if (barraDeVida.mostrarComoPorcentaje)
            {
                // Toma el nivel de llenado de la imagen (de 0.0 a 1.0) y lo convierte a porcentaje (0% a 100%)
                int porcentaje = Mathf.RoundToInt(barraDeVida.barraUI.fillAmount * 100f);
                barraDeVida.textoBarraUI.text = porcentaje + "%";
            }
        }
    }
}