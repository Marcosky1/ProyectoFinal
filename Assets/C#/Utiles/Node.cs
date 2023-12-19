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
    public bool estaOcupado;
    public TipoCliente tipoCliente;

    void Start()
    {
        estaLleno = false;
        tipoCliente = TipoCliente.Normal;
        estaOcupado = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cliente") || other.CompareTag("ClientePreference"))
        {
            estaLleno = true;

            // Verifica si el nodo anterior es null (último nodo)
            if (nodoAnterior == null)
            {
                Cliente clienteScript = other.GetComponent<Cliente>();
                if (clienteScript != null)
                {
                    clienteScript.ActivarCliente(true);
                }              
            }
        }     
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("cliente") || other.CompareTag("ClientePreference"))
        {
            estaLleno = false;
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
