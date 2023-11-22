using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cliente : MonoBehaviour
{
    private int paciencia;
    private int puntaje;
    private int estrellas;

    void Start()
    {
        paciencia = 100;
        puntaje = 50;
        estrellas = 5;

        RealizarPedido();
    }

    void RealizarPedido()
    {
        int cantidadPedido = Random.Range(1, 5);
        Debug.Log("Cliente ha hecho un pedido de " + cantidadPedido + " artículos.");

        while (cantidadPedido > 0)
        {
            System.Threading.Thread.Sleep(1000);
            Debug.Log("Preparando artículo...");

            paciencia--;

            if (paciencia == 0)
            {
                Debug.Log("¡Cliente se fue sin su pedido!");
                estrellas--;
                break;
            }

            cantidadPedido--;
        }

        if (paciencia > 0)
        {
            Debug.Log("¡Pedido entregado con éxito!");
            puntaje -= paciencia;
        }

        Debug.Log("Puntaje final del cliente: " + puntaje);
        Debug.Log("Estrellas del cliente: " + estrellas);
    }
}

