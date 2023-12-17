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
        for (int i = 0; i < cantidad; i++)
        {
            yield return new WaitForSeconds(intervalo);
            GenerarClientes(1);
        }
            
    }

    private void GenerarClientes(int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            int indiceNodo = nodos.Length - 1;  // Comienza en el �ltimo nodo

            Node nodoActual = nodos[indiceNodo].GetComponent<Node>();

            // Verifica si el nodo actual est� lleno
            if (nodoActual.estaLleno)
            {
                while (nodoActual.NodoSiguienteEstaLleno())
                {
                    nodoActual = nodoActual.nodoSiguiente;

                    // Si el siguiente nodo es nulo, significa que todos los nodos est�n llenos y no se pueden instanciar m�s clientes
                    if (nodoActual == null)
                    {
                        return;
                    }
                }
            }

            GameObject nuevoClientePrefab = (Random.value < ProbabilidadClientePreferencial) ? clientePreferencialPrefab : clientePrefab;

            GameObject nuevoClienteObject = Instantiate(nuevoClientePrefab, nodos[indiceNodo].transform.position, Quaternion.identity);

            Cliente nuevoClienteScript = nuevoClienteObject.GetComponent<Cliente>();

            if (nuevoClienteScript != null)
            {
                nuevoClienteScript.NodoDestino = nodos[indiceNodo].GetComponent<Node>();

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

            actual = actual.Siguiente;
            index++;
        }
    }
}
