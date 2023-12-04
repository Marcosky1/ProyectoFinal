using UnityEngine;
using UnityEngine.UI;

public class CrearHamburguesa : MonoBehaviour
{
    public Button botonHamburguesa;
    public Button botonPan;

    void Start()
    {
        botonPan.onClick.AddListener(ActivarHamburguesaYDesactivarPan);
        botonHamburguesa.onClick.AddListener(DesactivarHamburguesa);
    }

    void ActivarHamburguesaYDesactivarPan()
    {
        // Desactivar el bot�n de pan
        botonPan.gameObject.SetActive(false);

        // Activar el bot�n de hamburguesa
        botonHamburguesa.gameObject.SetActive(true);
    }
    void DesactivarHamburguesa()
    {
        // Desavtivar el bot�n de hamburguesa
        botonHamburguesa.gameObject.SetActive(false);
    }
}

