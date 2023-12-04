using UnityEngine;
using UnityEngine.UI;

public class CrearPan : MonoBehaviour
{
    public Button botonCarne;
    public Button botonPan;

    void Start()
    {
        // Aseg�rate de que el bot�n "pan" est� inicialmente oculto
        botonPan.gameObject.SetActive(false);

        // Asigna la funci�n MostrarBotonPan al evento de clic del bot�n "carne"
        botonCarne.onClick.AddListener(MostrarBotonPan);
    }

    void MostrarBotonPan()
    {
        botonPan.gameObject.SetActive(true);
        botonCarne.gameObject.SetActive(false);
    }
}


