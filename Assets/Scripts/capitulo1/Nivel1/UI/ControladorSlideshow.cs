using UnityEngine;
using UnityEngine.UI; // Obligatorio para manipular elementos de UI como 'Image'

public class ControladorSlideshow : MonoBehaviour
{
    [Header("Componente Visual")]
    public Image fondoPantalla;

    [Header("Configuración del Slideshow")]
    public Sprite[] imagenes; // Aquí pondremos las 3 imágenes
    public float tiempoPorImagen = 3.5f; // Segundos que dura cada imagen

    private int indiceActual = 0;
    private float temporizador = 0f;

    void Start()
    {
        // Asegurarnos de que inicie con la primera imagen si hay alguna configurada
        if (imagenes.Length > 0 && fondoPantalla != null)
        {
            fondoPantalla.sprite = imagenes[0];
        }
    }

    void Update()
    {
        // Si no hay imágenes o falta conectar el fondo, no hacemos nada
        if (imagenes.Length == 0 || fondoPantalla == null) return;

        // El temporizador avanza con el tiempo real
        temporizador += Time.deltaTime;

        // Si el tiempo supera nuestro límite, cambiamos la imagen
        if (temporizador >= tiempoPorImagen)
        {
            temporizador = 0f;
            SiguienteImagen();
        }
    }

    void SiguienteImagen()
    {
        indiceActual++;

        // Si llegamos al final del arreglo, volvemos a empezar (bucle infinito)
        if (indiceActual >= imagenes.Length)
        {
            indiceActual = 0;
        }

        // Asignamos la nueva imagen al componente de la interfaz
        fondoPantalla.sprite = imagenes[indiceActual];
    }
}