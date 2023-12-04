using UnityEngine;
using UnityEngine.UI;

public class CrearPan : MonoBehaviour
{
    public Button botonCarne;
    public Button botonPan;

    void Start()
    {
        // Asegúrate de que el botón "pan" esté inicialmente oculto
        botonPan.gameObject.SetActive(false);

        // Asigna la función MostrarBotonPan al evento de clic del botón "carne"
        botonCarne.onClick.AddListener(MostrarBotonPan);
    }

    void MostrarBotonPan()
    {
        botonPan.gameObject.SetActive(true);
        botonCarne.gameObject.SetActive(false);
    }
}


