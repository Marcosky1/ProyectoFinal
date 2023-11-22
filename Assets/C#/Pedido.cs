using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedido : MonoBehaviour

{
    public string Tipo { get; private set; }

    public Pedido(string tipo)
    {
        Tipo = tipo;
    }
}
/*
public class NodoPedido
{
    public Pedido Pedido { get; private set; }
    public NodoPedido Siguiente { get; set; }

    public NodoPedido(Pedido pedido)
    {
        Pedido = pedido;
        Siguiente = null;
    }
}

public class Cliente
{
    public int CantidadPedidos { get; private set; }

    public NodoPedido HeadPedido { get; private set; }

    public Cliente(int cantidadPedidos)
    {
        CantidadPedidos = cantidadPedidos;
        GenerarPedidos();
    }

    private void GenerarPedidos()
    {
                HeadPedido = null;

        for (int i = 0; i < CantidadPedidos; i++)
        {
            Pedido nuevoPedido = GenerarPedido();
            NodoPedido nuevoNodo = new NodoPedido(nuevoPedido);

            // Agregar el nuevo nodo a la lista enlazada
            if (HeadPedido == null)
            {
                HeadPedido = nuevoNodo;
            }
            else
            {
                NodoPedido ultimoNodo = ObtenerUltimoNodo();
                ultimoNodo.Siguiente = nuevoNodo;
            }
        }
    }

    private NodoPedido ObtenerUltimoNodo()
    {
        NodoPedido ultimoNodo = HeadPedido;
        while (ultimoNodo.Siguiente != null)
        {
            ultimoNodo = ultimoNodo.Siguiente;
        }
        return ultimoNodo;
    }

    private Pedido GenerarPedido()
    {
        float probabilidadFacil = 0.5f; 
        float probabilidadDificil = 0.2f; 

        // Ajustar las probabilidades según la ronda
        int ronda = GameData.Instance.RondaActual; 
        probabilidadFacil -= ronda * 0.02f; 
        probabilidadDificil += ronda * 0.01f; 

        float randomValue = Random.value;
        if (randomValue < probabilidadFacil)
        {
            return new Pedido("Facil de preparar");
        }
        else if (randomValue < probabilidadFacil + probabilidadDificil)
        {
            return new Pedido("Dificil de preparar");
        }
        else
        {
            return new Pedido("Tipo Default");
        }
    }
}
*/


