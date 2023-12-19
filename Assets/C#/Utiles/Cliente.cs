using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;

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
    public GameController gameController;

    public bool EsUltimoNodo { get; set; } = false;
    public Node NodoDestino { get; set; }

    private float tiempoPaciencia = 15f;
    private int puntos = 15;

    private bool clienteSatisfecho = false;
    private bool clienteActivo = false;
    private bool esPreferencial;
    private IEnumerator tiempoPacienciaCoroutine;
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
            Debug.Log("Cliente pidi�: " + ordenComida[i]);
        }
        tiempoPacienciaCoroutine = ActualizarTiempoPaciencia();
        StartCoroutine(tiempoPacienciaCoroutine);
    }

    void Update()
    {
        hamrburguesa = GameObject.FindGameObjectWithTag("Hamburguesa");
        papas = GameObject.FindGameObjectWithTag("papas");
        pollos = GameObject.FindGameObjectWithTag("pollo");
        gaseosas = GameObject.FindGameObjectWithTag("gaseosa");
        _gamecontroller = GameObject.FindGameObjectWithTag("Player");

        AsignarGameObjects();

        if (clienteActivo && !clienteSatisfecho)
        {
            tiempoPaciencia -= Time.deltaTime;

            if (tiempoPaciencia <= 0f)
            {
                clienteSatisfecho = true;
                Debug.Log("Cliente insatisfecho. Se ha agotado el tiempo.");

                StartCoroutine(InvocarEventoTiempoAgotado(esPreferencial));

                gameController.TiempoAgotado(esPreferencial);

                Destroy(gameObject);
            }
        }
    }

    void OnDestroy()
    {
        if (tiempoPacienciaCoroutine != null)
        {
            StopCoroutine(tiempoPacienciaCoroutine);
        }
        if (NodoDestino != null)
        {
            NodoDestino.estaOcupado = false;
        }
    }

    IEnumerator InvocarEventoTiempoAgotado(bool esPreferencial)
    {
        yield return null;
        OnTiempoAgotado?.Invoke(esPreferencial);
    }

    IEnumerator ActualizarTiempoPaciencia()
    {
        while (tiempoPaciencia > 0f && !clienteSatisfecho)
        {
            tiempoPaciencia -= 1f;

            if (tiempoPaciencia <= 0f)
            {
                clienteSatisfecho = true;
                Debug.Log("Cliente insatisfecho. Se ha agotado el tiempo.");

                OnTiempoAgotado?.Invoke(esPreferencial);

                Destroy(gameObject);
            }

            yield return new WaitForSeconds(1f);
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

    public void SeleccionarComida(string comida)
    {
        if (!clienteSatisfecho && ordenComida.Length > 0)
        {

            if (comida == ordenComida[0])
            {

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

                    gameController.ClienteSatisfecho(puntos);

                    Destroy(gameObject);
                }
            }
        }
    }

    public bool EsClienteSatisfecho()
    {
        return clienteSatisfecho;
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
