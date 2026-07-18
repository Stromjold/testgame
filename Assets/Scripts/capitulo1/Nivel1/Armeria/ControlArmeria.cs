using UnityEngine;
using UnityEngine.UI;
using TMPro; // NUEVO: Necesario para controlar el Text (TMP)

public class ControlArmeria : MonoBehaviour
{
    [System.Serializable]
    public class SlotDeArma
    {
        [Header("Información del Arma")]
        public string nombreParaIdentificar = "Nueva Arma"; 
        public int costoElemento = 80;
        public int indiceDelArmaEnSoldado; 

        [Header("Visuales y Prefabs (Control Central)")]
        public Sprite imagenDelArma;
        public Image imagenUIEnTienda;
        public GameObject prefabArma;

        [Header("Recursos y Precio (NUEVO)")]
        [Tooltip("El icono puro del recurso (cristal, orbe, etc.)")]
        public Sprite iconoElemento;
        [Tooltip("Arrastra aquí el objeto hijo 'Elemento' (Image) de tu arma")]
        public Image imagenUIElemento;
        [Tooltip("Arrastra aquí el objeto hijo 'Text (TMP)' de tu arma")]
        public TextMeshProUGUI textoCostoUI;

        [Header("Botones Físicos")]
        public Button botonAgregar;
        public Button botonUsar;

        [HideInInspector] public bool comprada = false;
    }

    [Header("Panel Visual de la Armería")]
    public GameObject panelArmeria;
    public bool pausarJuegoAlAbrir = true;

    [Header("--- CATÁLOGO DE ARMAS ---")]
    public SlotDeArma[] catalogoDeArmas;

    [Header("Los 5 Soldados")]
    public Soldier[] los5Soldados;
    public Image[] iconosSoldadosUI;

    private int indiceArmaPendiente = -1;
    private Sprite imagenArmaPendiente;

    // --- LA MAGIA EN TIEMPO REAL ACTUALIZADA ---
    void OnValidate()
    {
        if (catalogoDeArmas != null)
        {
            foreach (SlotDeArma arma in catalogoDeArmas)
            {
                // 1. Actualiza el dibujo del arma
                if (arma.imagenUIEnTienda != null && arma.imagenDelArma != null)
                {
                    arma.imagenUIEnTienda.sprite = arma.imagenDelArma;
                }

                // 2. Actualiza el icono del recurso (cristal, orbe, etc.)
                if (arma.imagenUIElemento != null && arma.iconoElemento != null)
                {
                    arma.imagenUIElemento.sprite = arma.iconoElemento;
                }

                // 3. Actualiza el texto de los puntos automáticamente
                if (arma.textoCostoUI != null)
                {
                    arma.textoCostoUI.text = arma.costoElemento.ToString() + " pts";
                }
            }
        }
    }

    void Start()
    {
        if (panelArmeria != null) panelArmeria.SetActive(false);

        for (int i = 0; i < catalogoDeArmas.Length; i++)
        {
            int index = i; 
            SlotDeArma arma = catalogoDeArmas[i];

            if (arma.botonAgregar != null)
            {
                arma.botonAgregar.interactable = false;
                arma.botonAgregar.onClick.AddListener(() => ComprarArma(index));
            }

            if (arma.botonUsar != null)
            {
                arma.botonUsar.gameObject.SetActive(false);
                arma.botonUsar.onClick.AddListener(() => PrepararArmaParaEquipar(index));
            }
        }
    }

    void Update()
    {
        if (GameManager.instance == null) return;

        foreach (SlotDeArma arma in catalogoDeArmas)
        {
            if (!arma.comprada && arma.botonAgregar != null)
            {
                arma.botonAgregar.interactable = (GameManager.instance.cristales >= arma.costoElemento);
            }
        }
    }

    public void AlternarArmeria()
    {
        if (panelArmeria != null)
        {
            bool nuevoEstado = !panelArmeria.activeSelf;
            panelArmeria.SetActive(nuevoEstado);
            if (pausarJuegoAlAbrir) Time.timeScale = nuevoEstado ? 0f : 1f;
        }
    }

    private void ComprarArma(int indexArray)
    {
        SlotDeArma arma = catalogoDeArmas[indexArray];

        if (GameManager.instance != null && GameManager.instance.cristales >= arma.costoElemento)
        {
            GameManager.instance.cristales -= arma.costoElemento;
            arma.comprada = true;

            if (arma.botonAgregar != null) arma.botonAgregar.gameObject.SetActive(false);
            if (arma.botonUsar != null) arma.botonUsar.gameObject.SetActive(true);
        }
    }

    private void PrepararArmaParaEquipar(int indexArray)
    {
        SlotDeArma arma = catalogoDeArmas[indexArray];
        indiceArmaPendiente = arma.indiceDelArmaEnSoldado;
        imagenArmaPendiente = arma.imagenDelArma;
        Debug.Log("Arma en espera: " + arma.nombreParaIdentificar + ". Haz clic en un soldado.");
    }

    public void EquiparASoldadoEspecifico(int numeroSoldado)
    {
        if (indiceArmaPendiente == -1) return;

        if (numeroSoldado >= 0 && numeroSoldado < los5Soldados.Length)
        {
            Soldier soldadoSeleccionado = los5Soldados[numeroSoldado];
            if (soldadoSeleccionado != null) soldadoSeleccionado.CambiarArma(indiceArmaPendiente);

            if (numeroSoldado < iconosSoldadosUI.Length && iconosSoldadosUI[numeroSoldado] != null)
            {
                iconosSoldadosUI[numeroSoldado].sprite = imagenArmaPendiente;
                iconosSoldadosUI[numeroSoldado].color = new Color(1, 1, 1, 1);
            }

            indiceArmaPendiente = -1; 
            imagenArmaPendiente = null;
        }
    }
}