using UnityEngine;
using UnityEngine.UI;

public class ControladorBotones : MonoBehaviour
{
    public Button botonCarne;
    public Button[] botonesOcultos;

    public int indiceBotonActual = 0;
    private bool activo = false;

    void Start()
    {
        botonCarne.onClick.AddListener(ActivarSiguienteBoton);
    }

    void ActivarSiguienteBoton()
    {
        if (activo)
        {
            botonesOcultos[indiceBotonActual].gameObject.SetActive(false);
            activo = false;
        }

        // Incrementar el índice del botón actual
        indiceBotonActual = (indiceBotonActual + 1) % botonesOcultos.Length;

        // Activar el nuevo botón y establecer el temporizador para ocultarlo después de 15 segundos
        botonesOcultos[indiceBotonActual].gameObject.SetActive(true);
        activo = true;
        Invoke("OcultarBoton", 5f);
    }

    void OcultarBoton()
    {
        // Ocultar el botón después de 15 segundos
        botonesOcultos[indiceBotonActual].gameObject.SetActive(false);
        ActivarSiguienteBoton();
    }
}

