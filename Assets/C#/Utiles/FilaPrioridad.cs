using System.Collections;
using UnityEngine;
using System;

public class Nodo
{
    public Transform ClientePrefab { get; set; }
    public Nodo Siguiente { get; set; }

    public Nodo(Transform clientePrefab)
    {
        ClientePrefab = clientePrefab;
        Siguiente = null;
    }
}


public class FilaPrioridad : MonoBehaviour
{
    protected Nodo cabeza;

    public virtual void ActualizarPosiciones()
    {
        Nodo actual = cabeza;
        int index = 0;
        while (actual != null)  
        {
            float yPos = index * 2f;
            actual.ClientePrefab.position = new Vector3(0f, yPos, 0f);
            actual = actual.Siguiente;
            index++;
        }
    }

    public void AgregarClienteEnNodo(Transform clientePrefab)
    {
        Nodo nuevoNodo = new Nodo(clientePrefab);
        nuevoNodo.Siguiente = cabeza;
        cabeza = nuevoNodo;
        ActualizarPosiciones();
    }

    public void EliminarCliente()
    {
        if (cabeza != null)
        {
            Transform cliente = cabeza.ClientePrefab;
            cabeza = cabeza.Siguiente;
            GameObject.Destroy(cliente.gameObject);
            ActualizarPosiciones();
        }
    }

    public int CantidadClientesEnFila()
    {
        int contador = 0;
        Nodo actual = cabeza;
        while (actual != null)
        {
            contador++;
            actual = actual.Siguiente;
        }
        return contador;
    }

    public void VaciarFila()
    {
        cabeza = null;
    }

}



