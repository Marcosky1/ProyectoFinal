using UnityEngine;
using System.Collections.Generic;
using System;


public class Ronda : MonoBehaviour
{
    public int numeroRonda;
    public float pacienciaCliente;
    public Queue<Cliente> clientes;


    // Definir evento para finalizar ronda
    public event Action OnRondaFinalizada;

    void IniciarRonda()
    {
        // Inicializar clientes y otros elementos de la ronda
    }

    void FinalizarRonda()
    {
        // Manejar la lógica de finalización de la ronda
        OnRondaFinalizada?.Invoke();
    }

    void GenerarCliente()
    {
        // Lógica para generar un nuevo cliente
    }

    void VerificarPedido()
    {
        // Lógica para verificar si el pedido del cliente es correcto
    }
}
