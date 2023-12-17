using UnityEngine;
using System.Collections;

public class GeneradorClientes : FilaPrioridad
{
    public GameObject clientePrefab;
    public GameObject clientePreferencialPrefab;
    public GameObject[] nodos;
    public GameData gameData;
    public int cantidad;

    private float ProbabilidadClientePreferencial = 0.2f;

    void Start()
    {
        StartCoroutine(GenerarClientesPeriodicamente(2f));
    }

    private IEnumerator GenerarClientesPeriodicamente(float intervalo)
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalo);
            GenerarClientes(1); 
        }
    }

    private void GenerarClientes(int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            int indiceNodo = nodos.Length - 1;  // Comienza en el último nodo

            Node nodoActual = nodos[indiceNodo].GetComponent<Node>();

            // Verifica si el nodo está vacío
            if (!nodoActual.estaLleno)
            {
                GameObject nuevoClientePrefab = (Random.value < ProbabilidadClientePreferencial) ? clientePreferencialPrefab : clientePrefab;

                // Verifica si el nodo siguiente está lleno
                if (nodoActual.nodoSiguiente != null && nodoActual.nodoSiguiente.estaLleno)
                {
                    Debug.Log("Nodo siguiente está lleno. No se puede avanzar al siguiente cliente.");
                    return;
                }

                GameObject nuevoClienteObject = Instantiate(nuevoClientePrefab, nodos[indiceNodo].transform.position, Quaternion.identity);

                Cliente nuevoClienteScript = nuevoClienteObject.GetComponent<Cliente>();

                if (nuevoClienteScript != null)
                {
                    AgregarClienteEnNodo(nuevoClienteObject);
                    nuevoClienteScript.ActivarCliente(true);

                    // Marca el nodo actual como lleno y asigna el tipo de cliente
                    nodoActual.ClienteEntra((Random.value < ProbabilidadClientePreferencial) ? TipoCliente.VIP : TipoCliente.Normal);
                }
                else
                {
                    Destroy(nuevoClienteObject);
                }
            }
            else
            {
                Debug.Log("Nodo actual está lleno. Esperando...");
            }
        }
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
