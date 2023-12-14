using UnityEngine;
using System;
using UnityEngine.UI;

public class Cliente : MonoBehaviour
{
    public Button btnHamburguesa;
    public Button btnPapas;
    public Button btnPollo;
    public Button btnGaseosa;

    public Text tiempoRestanteText;
    public Text estrellasText;

    public GameController gameController;

    private float tiempoPaciencia = 10f;
    private int estrellas = 5;
    private int puntos = 50;

    private bool clienteSatisfecho = false;

    private string[] tiposComida = { "Hamburguesa", "Papas", "Pollo", "Gaseosa" };
    private string[] ordenComida;

    void Start()
    {
        System.Random random = new System.Random();
        int cantidadPedido = random.Next(2, 4);
        ordenComida = new string[cantidadPedido];

        for (int i = 0; i < cantidadPedido; i++)
        {
            ordenComida[i] = tiposComida[random.Next(0, tiposComida.Length)];
            Debug.Log("Cliente pidió: " + ordenComida[i]);
        }

        // Add listeners using regular methods
        btnHamburguesa.onClick.AddListener(SeleccionarHamburguesa);
        btnPapas.onClick.AddListener(SeleccionarPapas);
        btnPollo.onClick.AddListener(SeleccionarPollo);
        btnGaseosa.onClick.AddListener(SeleccionarGaseosa);

        InvokeRepeating("ActualizarTiempoPaciencia", 0f, 1f);
    }

    void SeleccionarHamburguesa()
    {
        SeleccionarComida("Hamburguesa");
    }

    void SeleccionarPapas()
    {
        SeleccionarComida("Papas");
    }

    void SeleccionarPollo()
    {
        SeleccionarComida("Pollo");
    }

    void SeleccionarGaseosa()
    {
        SeleccionarComida("Gaseosa");
    }

    void SeleccionarComida(string comida)
    {
        if (!clienteSatisfecho && ordenComida.Length > 0 && comida == ordenComida[0])
        {
            Debug.Log("Cliente seleccionó: " + comida);

            if (puntos <= 0 && ordenComida.Length > 0)
            {
                puntos += 2;
                gameController.SumarPuntos(2);
            }

            if (ordenComida.Length > 1)
            {
                Array.Resize(ref ordenComida, ordenComida.Length - 1);
            }
            else
            {
                ordenComida = new string[0];
            }

            if (ordenComida.Length == 0)
            {
                clienteSatisfecho = true;
                Debug.Log("Cliente satisfecho!");
                CancelInvoke("ActualizarTiempoPaciencia");
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

            // Llamar al método en el GameController para actualizar estrellas
            gameController.ActualizarEstrellas();

            Destroy(gameObject);
        }
    }
}
