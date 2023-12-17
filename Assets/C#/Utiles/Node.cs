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
}


