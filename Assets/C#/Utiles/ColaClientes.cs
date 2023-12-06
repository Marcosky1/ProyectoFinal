using UnityEngine;

public class ColaClientes : MonoBehaviour
{
    private class NodoCliente
    {
        public GameObject cliente;
        public NodoCliente siguiente;

        public NodoCliente(GameObject cliente)
        {
            this.cliente = cliente;
            this.siguiente = null;
        }
    }

    private NodoCliente primero;
    private NodoCliente ultimo;

    void Start()
    {
        AgregarCliente(new GameObject("Cliente1"));
        AgregarCliente(new GameObject("Cliente2"));
        AgregarCliente(new GameObject("Cliente3"));

        Invoke("EliminarPrimerCliente", 5f);
    }

    void AgregarCliente(GameObject cliente)
    {
        NodoCliente nuevoNodo = new NodoCliente(cliente);

        if (ultimo == null)
        {
            primero = nuevoNodo;
            ultimo = nuevoNodo;
        }
        else
        {
            ultimo.siguiente = nuevoNodo;
            ultimo = nuevoNodo;
        }
    }

    void EliminarPrimerCliente()
    {
        if (primero != null)
        {
            GameObject clienteEliminado = primero.cliente;
            primero = primero.siguiente;

            Destroy(clienteEliminado);
        }
    }
}
