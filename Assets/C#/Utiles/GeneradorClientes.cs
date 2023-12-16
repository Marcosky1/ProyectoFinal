using UnityEngine;
using System.Collections;

public class GeneradorClientes : FilaPrioridad
{
    public GameObject clientePrefab;
    public GameObject clientePreferencialPrefab;
    public GameObject[] nodos;
    public GameData gameData;

    private float ProbabilidadClientePreferencial = 0.2f;
    private bool generandoClientes = false;

    void Start()
    {
        // Genera 4 clientes iniciales
        GenerarClientes(4);
    }

    private void Update()
    {
        // Verifica si la fila está vacía y no está generando clientes actualmente
        if (CantidadClientesEnFila() == 0 && !generandoClientes)
        {
            // Espera 5 segundos y luego genera 4 clientes
            StartCoroutine(EsperarYGenerarClientes(5f, 4));
        }
    }

    private void GenerarClientes(int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            // Decide si el siguiente cliente será preferencial o no
            GameObject nuevoClientePrefab = (Random.value < ProbabilidadClientePreferencial) ? clientePreferencialPrefab : clientePrefab;

            // Elegir un nodo aleatorio para colocar al cliente
            int indiceNodo = Random.Range(0, nodos.Length);

            // Instancia el nuevo cliente en la posición del nodo
            GameObject nuevoClienteObject = Instantiate(nuevoClientePrefab, nodos[indiceNodo].transform.position, Quaternion.identity);

            // Accede al script Cliente si existe y activa el cliente
            Cliente nuevoClienteScript = nuevoClienteObject.GetComponent<Cliente>();
            if (nuevoClienteScript != null)
            {
                // Agrega el cliente a la fila
                AgregarClienteEnNodo(nuevoClienteObject);
            }
            else
            {
                // Si el componente Cliente no está presente, destruye el objeto recién creado
                Destroy(nuevoClienteObject);
            }
        }
    }


    private IEnumerator EsperarYGenerarClientes(float tiempoEspera, int cantidad)
    {
        generandoClientes = true;
        yield return new WaitForSeconds(tiempoEspera);
        GenerarClientes(cantidad);
        generandoClientes = false;
    }

    // Actualizado para tomar solo un argumento
    public void AgregarClienteEnNodo(GameObject cliente)
    {
        Nodo nuevoNodo = new Nodo(cliente.transform);
        nuevoNodo.Siguiente = cabeza;
        cabeza = nuevoNodo;
        ActualizarPosiciones();
    }
}
