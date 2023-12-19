using UnityEngine;

public class InstanciadorClientes : MonoBehaviour
{
    public GameObject clientePrefab;
    public GameObject clientePreferencialPrefab;
    public Node nodo;
    public GameData gameData;
    private int clientesAtendidos = 0;

    void Start()
    {
        InstanciarClienteSiEsPosible();
    }

    void Update()
    {      
        InstanciarClienteSiEsPosible();
        ClientesAtendidos();
    }

    void InstanciarClienteSiEsPosible()
    {
        if (nodo != null && !nodo.estaOcupado)
        {
            InstanciarCliente();
            clientesAtendidos++;
        }
    }

    void ClientesAtendidos()
    {
        if(clientesAtendidos >= 4)
        {
            gameData.AumentarRonda();
            clientesAtendidos = 0;
        }
    }

    void InstanciarCliente()
    {
        // Usa una probabilidad del 80% para cliente normal y 20% para cliente preferencial
        float probabilidadClientePreferencial = 0.2f;
        float probabilidad = Random.value;

        GameObject nuevoClientePrefab = (probabilidad < probabilidadClientePreferencial) ? clientePreferencialPrefab : clientePrefab;

        // Instancia un cliente en la posición del nodo
        if (nuevoClientePrefab != null && nodo != null)
        {
            GameObject nuevoClienteObject = Instantiate(nuevoClientePrefab, nodo.transform.position, Quaternion.identity);
            Cliente nuevoClienteScript = nuevoClienteObject.GetComponent<Cliente>();
            if (nuevoClienteScript != null)
            {
                nuevoClienteScript.NodoDestino = nodo;
                nodo.estaOcupado = true;
            }            
        }
    }
}