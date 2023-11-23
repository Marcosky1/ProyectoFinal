using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ronda : MonoBehaviour
{
    private int numeroRonda;
    private float pacienciaCliente;
    private Queue<Cliente> clientes;
    private Jugador jugador;

    void Start()
    {
        IniciarRonda();
    }

    void Update()
    {
        VerificarPedidoContinuamente();
    }

    private void IniciarRonda()
    {
        for (int i = 0; i < numeroRonda + 5; i++)
        {
            GenerarCliente();
        }
        Debug.Log("Iniciando Ronda " + numeroRonda);
    }

    private void VerificarPedidoContinuamente()
    {
        if (clientes.Count > 0)
        {
            Cliente clienteActual = clientes.Peek();

            if (jugador.ComidaServida != null && clienteActual.Pedido == jugador.ComidaServida.tag)
            {
                Debug.Log("Pedido correcto en Ronda " + numeroRonda + ": " + clienteActual.Pedido);
                jugador.AgregarPuntos(10);
                clientes.Dequeue();
            }
            
            jugador.ComidaServida = null;
        }
    }

    private void GenerarCliente()
    {
        Cliente nuevoCliente = new Cliente(pacienciaCliente);
        clientes.Enqueue(nuevoCliente);
        Debug.Log("Cliente encolado en Ronda " + numeroRonda + ": Paciencia " + pacienciaCliente);
    }

    private void FinalizarRonda()
    {
        Debug.Log("Finalizando Ronda " + numeroRonda);
    }
}
