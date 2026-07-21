using UnityEngine;
using UnityEngine.UI;
using TMPro; 

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

        [Header("Recursos y Precio")]
        public Sprite iconoElemento;
        public Image imagenUIElemento;
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

    [Header("Los 5 Soldados (Solo Interfaz)")]
    public Image[] iconosSoldadosUI;

    private int indiceArmaPendiente = -1;
    private Sprite imagenArmaPendiente;

    void OnValidate()
    {
        if (catalogoDeArmas != null)
        {
            foreach (SlotDeArma arma in catalogoDeArmas)
            {
                if (arma.imagenUIEnTienda != null && arma.imagenDelArma != null) arma.imagenUIEnTienda.sprite = arma.imagenDelArma;
                if (arma.imagenUIElemento != null && arma.iconoElemento != null) arma.imagenUIElemento.sprite = arma.iconoElemento;
                if (arma.textoCostoUI != null) arma.textoCostoUI.text = arma.costoElemento.ToString() + " pts";
            }
        }
    }

    void Start()
    {
        if (panelArmeria != null) panelArmeria.SetActive(false);

        GameLogger.LogToFile("ControlArmeria", $"Armería inicializada. Total de armas en catálogo: {catalogoDeArmas.Length}");

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
                arma.botonAgregar.interactable = (GameManager.instance.cristales >= arma.costoElemento);
        }
    }

    public void AlternarArmeria()
    {
        if (panelArmeria != null)
        {
            bool nuevoEstado = !panelArmeria.activeSelf;
            panelArmeria.SetActive(nuevoEstado);
            if (pausarJuegoAlAbrir) Time.timeScale = nuevoEstado ? 0f : 1f;

            GameLogger.LogToFile("ControlArmeria", $"Armería alternada. Estado visible: {nuevoEstado} | Juego pausado: {pausarJuegoAlAbrir && nuevoEstado}");
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

            GameLogger.LogToFile("ControlArmeria", $"[COMPRA EXITOSA] Arma comprada: '{arma.nombreParaIdentificar}' por {arma.costoElemento} cristales.");
        }
        else
        {
            GameLogger.LogToFile("ControlArmeria", $"[FALLO DE COMPRA] Intento fallido de comprar '{arma.nombreParaIdentificar}'. Cristales insuficientes.");
        }
    }

    private void PrepararArmaParaEquipar(int indexArray)
    {
        SlotDeArma arma = catalogoDeArmas[indexArray];
        indiceArmaPendiente = arma.indiceDelArmaEnSoldado;
        imagenArmaPendiente = arma.imagenDelArma;

        GameLogger.LogToFile("ControlArmeria", $"Arma preparada para equipar: '{arma.nombreParaIdentificar}' (Índice de arma: {indiceArmaPendiente})");
    }

    public void EquiparASoldadoEspecifico(int numeroSoldado)
    {
        if (indiceArmaPendiente == -1)
        {
            GameLogger.LogToFile("ControlArmeria", $"[ADVERTENCIA] Se intentó equipar a un soldado (Pos {numeroSoldado}), pero no hay ningún arma pendiente.");
            return;
        }

        // Conexión con el nuevo Controlador Maestro
        if (ControlSoldados.instance != null)
        {
            ControlSoldados.instance.CambiarArmaDeSoldado(numeroSoldado, indiceArmaPendiente);

            if (numeroSoldado < iconosSoldadosUI.Length && iconosSoldadosUI[numeroSoldado] != null)
            {
                iconosSoldadosUI[numeroSoldado].sprite = imagenArmaPendiente;
                iconosSoldadosUI[numeroSoldado].color = new Color(1, 1, 1, 1);
            }

            GameLogger.LogToFile("ControlArmeria", $"[EQUIPADO] Arma asignada exitosamente al Soldado en la posición [{numeroSoldado}].");

            indiceArmaPendiente = -1; 
            imagenArmaPendiente = null;
        }
        else
        {
            GameLogger.LogToFile("ControlArmeria", $"[ERROR] ControlSoldados.instance es NULL. No se pudo asignar el arma al soldado [{numeroSoldado}].");
        }
    }
}