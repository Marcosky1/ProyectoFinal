using UnityEngine;

public enum TipoCliente
{
    Normal,
    VIP
}

public class Node : MonoBehaviour
{
    public Node nodoAnterior;
    public Node nodoSiguiente;
    public bool estaLleno;
    public TipoCliente tipoCliente;

    void Start()
    {
        estaLleno = false;
        tipoCliente = TipoCliente.Normal;
    }

    

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colision� es un cliente o un cliente preferencial
        if (other.CompareTag("cliente") || other.CompareTag("ClientePreference"))
        {
            estaLleno = true;
            tipoCliente = other.CompareTag("ClientePreference") ? TipoCliente.VIP : TipoCliente.Normal;

            Debug.Log("Colisi�n detectada. Nodo " + name + " est� lleno. Tipo de cliente: " + tipoCliente);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica si el objeto que dej� de colisionar es un cliente o un cliente preferencial
        if (other.CompareTag("cliente") || other.CompareTag("ClientePreference"))
        {

            estaLleno = false;
            tipoCliente = TipoCliente.Normal; 

            Debug.Log("Colisi�n terminada. Nodo " + name + " ya no est� lleno.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cliente"))
        {
            // Si colisiona con un cliente, activa su script
            Cliente clienteScript = collision.gameObject.GetComponent<Cliente>();
            if (clienteScript != null)
            {
                clienteScript.ActivarCliente(true);
            }
        }
    }

    public void ClienteEntra(TipoCliente tipo)
    {
        estaLleno = true;
        tipoCliente = tipo;
    }

    public void ClienteSale()
    {
        estaLleno = false;
        tipoCliente = TipoCliente.Normal;
    }

    public bool NodoSiguienteEstaLleno()
    {
        return nodoSiguiente != null && nodoSiguiente.estaLleno;
    }
}
