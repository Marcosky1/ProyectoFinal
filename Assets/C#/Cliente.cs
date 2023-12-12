using UnityEngine;
using UnityEngine.UI;

public class Cliente : MonoBehaviour
{
    public Button btnHamburguesa;
    public Button btnPapas;
    public Button btnPollo;
    public Button btnGaseosa;

    public Text tiempoRestanteText;
    public Text estrellasText;

    private float tiempoPaciencia = 10f;
    private int estrellas = 5;
    private int puntos = 50;

    private bool clienteSatisfecho = false;

    void Start()
    {
        btnHamburguesa.onClick.AddListener(() => SeleccionarComida("Hamburguesa"));
        btnPapas.onClick.AddListener(() => SeleccionarComida("Papas"));
        btnPollo.onClick.AddListener(() => SeleccionarComida("Pollo"));
        btnGaseosa.onClick.AddListener(() => SeleccionarComida("Gaseosa"));

        InvokeRepeating("ActualizarTiempoPaciencia", 0f, 1f);
    }

    void SeleccionarComida(string comida)
    {
        if (!clienteSatisfecho)
        {
            if (comida == "Hamburguesa" || comida == "Papas" || comida == "Pollo" || comida == "Gaseosa")
            {
                Debug.Log("Cliente pidió: " + comida);
                puntos -= 2;
                if (puntos <= 0)
                {
                    clienteSatisfecho = true;
                    Debug.Log("Cliente satisfecho!");
                    CancelInvoke("ActualizarTiempoPaciencia");
                    // Aquí podrías agregar lógica adicional cuando el cliente está satisfecho.
                }
            }
        }
    }

    void ActualizarTiempoPaciencia()
    {
        tiempoPaciencia -= 1f;
        tiempoRestanteText.text = "Tiempo Restante: " + tiempoPaciencia.ToString("F0") + "s";

        if (tiempoPaciencia <= 0f)
        {
            clienteSatisfecho = true;
            Debug.Log("Cliente insatisfecho. Se ha agotado el tiempo.");
            estrellas--;
            estrellasText.text = "Estrellas: " + estrellas;
            Destroy(gameObject);
        }
    }
}


