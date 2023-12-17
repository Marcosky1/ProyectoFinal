using UnityEngine;
using System;
using UnityEngine.UI;

public class Cliente : MonoBehaviour
{
    public delegate void ClienteAtendidoEventHandler(bool esPreferencial);
    public static event ClienteAtendidoEventHandler OnClienteAtendido;

    public delegate void TiempoAgotadoEventHandler(bool esPreferencial);
    public static event TiempoAgotadoEventHandler OnTiempoAgotado;

    public Button btnHamburguesa;
    public Button btnPapas;
    public Button btnPollo;
    public Button btnGaseosa;
    public Text tiempoRestanteText;
    public GameController gameController;

    private float tiempoPaciencia = 20f;
    private int puntos = 50;

    private bool clienteSatisfecho = false;
    private bool clienteActivo = false;
    private bool esPreferencial;

    private string[] tiposComida = { "Hamburguesa", "Papas", "Pollo", "Gaseosa" };
    public string[] ordenComida;

    private GameObject hamrburguesa;
    private GameObject papas;
    private GameObject pollos;
    private GameObject gaseosas;
    private GameObject _gamecontroller;
    private GameObject _tiempoRestante;


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
        InvokeRepeating("ActualizarTiempoPaciencia", 0f, 1f);
    }

    void Update()
    {
        hamrburguesa = GameObject.FindGameObjectWithTag("Hamburguesa");
        papas = GameObject.FindGameObjectWithTag("papas");
        pollos = GameObject.FindGameObjectWithTag("pollo");
        gaseosas = GameObject.FindGameObjectWithTag("gaseosa");
        _gamecontroller = GameObject.FindGameObjectWithTag("Player");
        _tiempoRestante = GameObject.FindGameObjectWithTag("tr");

        AsignarGameObjects();
        if (clienteActivo && !clienteSatisfecho)
        {
            tiempoPaciencia -= Time.deltaTime;
            tiempoRestanteText.text = "Tiempo Restante: " + tiempoPaciencia.ToString("F0") + "s";

            if (tiempoPaciencia <= 0f)
            {
                clienteSatisfecho = true;
                Debug.Log("Cliente insatisfecho. Se ha agotado el tiempo.");

                OnTiempoAgotado?.Invoke(esPreferencial);

                Destroy(gameObject);
            }
        }
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
        if (!clienteSatisfecho && ordenComida.Length > 0)
        {           

            if (comida == ordenComida[0])
            {
                if (puntos <= 0 && ordenComida.Length > 0)
                {
                    puntos += 2;
                    gameController.SumarPuntos(2);
                }

                if (ordenComida.Length > 1)
                {
                    string[] nuevaOrdenComida = new string[ordenComida.Length - 1];

                    for (int i = 1; i < ordenComida.Length; i++)
                    {
                        nuevaOrdenComida[i - 1] = ordenComida[i];
                    }
                    ordenComida = nuevaOrdenComida;
                }
                else
                {
                    ordenComida = new string[0];
                }

                if (ordenComida.Length == 0)
                {
                    clienteSatisfecho = true;
                    Debug.Log("Cliente satisfecho!");

                    OnClienteAtendido?.Invoke(esPreferencial);
                    CancelInvoke("ActualizarTiempoPaciencia");

                    Destroy(gameObject);
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

            OnTiempoAgotado?.Invoke(esPreferencial);

            Destroy(gameObject);
        }
    }

    public void AsignarGameObjects()
    {
        if (hamrburguesa != null)
        {
            btnHamburguesa = hamrburguesa.GetComponent<Button>();
        }
        if (papas != null)
        {
            btnPapas = papas.GetComponent<Button>();
        }
        if (pollos != null)
        {
            btnPollo = pollos.GetComponent<Button>();
        }
        if (gaseosas != null)
        {
            btnGaseosa = gaseosas.GetComponent<Button>();
        }
        if (_gamecontroller != null)
        {
            gameController = _gamecontroller.GetComponent<GameController>();
        }
        if (_tiempoRestante != null)
        {
            tiempoRestanteText = _tiempoRestante.GetComponent<Text>();
        }

        if (btnHamburguesa != null)
        {
            btnHamburguesa.onClick.AddListener(SeleccionarHamburguesa);
        }
        if (btnPapas != null)
        {
            btnPapas.onClick.AddListener(SeleccionarPapas);
        }
        if (btnPollo != null)
        {
            btnPollo.onClick.AddListener(SeleccionarPollo);
        }
        if (btnGaseosa != null)
        {
            btnGaseosa.onClick.AddListener(SeleccionarGaseosa);
        }
    }
    public void ActivarCliente(bool activar)
    {
        gameObject.SetActive(activar);
    }
}
