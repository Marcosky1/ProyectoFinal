using UnityEngine;
using UnityEngine.UI;

public class CrearFrituras : MonoBehaviour
{
    public Button botonFritura;
    public Button botonFrituraFinal;

    void Start()
    {
        botonFritura.onClick.AddListener(ActivarPapasFritasYDesactivarPapas);
        botonFrituraFinal.onClick.AddListener(ActivarPapasYDesactivarPapasFritas);
    }

    void ActivarPapasFritasYDesactivarPapas()
    {
        // Desactivar el bot�n de papas
        botonFritura.gameObject.SetActive(false);

        // Activar el bot�n de papas fritas
        botonFrituraFinal.gameObject.SetActive(true);
    }

    void ActivarPapasYDesactivarPapasFritas()
    {
        // Desactivar el bot�n de papas fritas
        botonFrituraFinal.gameObject.SetActive(false);

        // Activar el bot�n de papas
        botonFritura.gameObject.SetActive(true);
    }
}
