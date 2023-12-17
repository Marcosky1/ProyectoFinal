using UnityEngine;
using System.Collections;

public class GeneradorClientes : FilaPrioridad
{
    public GameObject clientePrefab;
    public GameObject clientePreferencialPrefab;
    public GameObject[] nodos;
    public GameData gameData;
    public int cantidad;

    private int clienteActual = 0;
    private float ProbabilidadClientePreferencial = 0.2f;
    private bool generandoClientes = false;

    void Start()
    {
        GenerarClientes(cantidad);
    }

    private void Update()
    {
        if (CantidadClientesEnFila() == 0 && !generandoClientes)
        {
            StartCoroutine(EsperarYGenerarClientes(5f, 4));
        }
    }

    private void GenerarClientes(int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            GameObject nuevoClientePrefab = (Random.value < ProbabilidadClientePreferencial) ? clientePreferencialPrefab : clientePrefab;

            int indiceNodo = Random.Range(0, nodos.Length);

            GameObject nuevoClienteObject = Instantiate(nuevoClientePrefab, nodos[indiceNodo].transform.position, Quaternion.identity);

            Cliente nuevoClienteScript = nuevoClienteObject.GetComponent<Cliente>();
            if (nuevoClienteScript != null)
            {
                AgregarClienteEnNodo(nuevoClienteObject);
                if (indiceNodo == 0)
                {
                    AgregarClienteEnNodo(nuevoClienteObject);
                    nuevoClienteScript.ActivarCliente(false);
                }
            }
            else
            {              
                Destroy(nuevoClienteObject);
            }

            if (i == 0)
            {
                Cliente primerClienteScript = nuevoClienteObject.GetComponent<Cliente>();
                if (primerClienteScript != null)
                {
                    primerClienteScript.ActivarCliente(true);
                }
            }
        }
        ActivarSiguienteCliente();
    }

    public void ActivarSiguienteCliente()
    {
        if (cabeza != null)
        {
            Nodo clienteAnteriorNodo = (clienteActual > 0) ? ObtenerNodo(clienteActual - 1) : null;
            Nodo clienteActualNodo = ObtenerNodo(clienteActual);

            if (clienteAnteriorNodo != null)
            {
                Cliente clienteAnteriorScript = clienteAnteriorNodo.ClientePrefab.GetComponent<Cliente>();
                if (clienteAnteriorScript != null)
                {
                    clienteAnteriorScript.ActivarCliente(false);
                }
            }

            if (clienteActualNodo != null)
            {
                Cliente clienteActualScript = clienteActualNodo.ClientePrefab.GetComponent<Cliente>();
                if (clienteActualScript != null)
                {
                    clienteActualScript.ActivarCliente(true);
                }

                clienteActual++;
            }
        }
    }

    private Nodo ObtenerNodo(int indice)
    {
        Nodo clienteActualNodo = cabeza;
        for (int i = 0; i < indice; i++)
        {
            clienteActualNodo = clienteActualNodo.Siguiente;
            if (clienteActualNodo == null)
            {
                return null;
            }
        }
        return clienteActualNodo;
    }

    private IEnumerator EsperarYGenerarClientes(float tiempoEspera, int cantidad)
    { 
        generandoClientes = true;
        yield return new WaitForSeconds(tiempoEspera);
        GenerarClientes(cantidad);
        generandoClientes = false;
    }

    public void AgregarClienteEnNodo(GameObject cliente)
    {
        Nodo nuevoNodo = new Nodo(cliente.transform);
        nuevoNodo.Siguiente = cabeza;
        cabeza = nuevoNodo;
        ActualizarPosiciones();
    }
    public override void ActualizarPosiciones()
    {
        Nodo actual = cabeza;
        int index = 0;
        while (actual != null)
        {
            if (index < nodos.Length)
            {
                actual.ClientePrefab.position = nodos[index].transform.position;
            }
            else
            {
                Debug.LogWarning("No hay suficientes nodos para la cantidad de clientes.");
            }

            actual = actual.Siguiente;
            index++;
        }
    }

}
