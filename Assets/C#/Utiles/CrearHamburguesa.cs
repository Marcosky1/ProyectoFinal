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
        // Desactivar el botón de pan
        botonPan.gameObject.SetActive(false);

        // Activar el botón de hamburguesa
        botonHamburguesa.gameObject.SetActive(true);
    }
    void DesactivarHamburguesa()
    {
        // Desavtivar el botón de hamburguesa
        botonHamburguesa.gameObject.SetActive(false);
    }
}

