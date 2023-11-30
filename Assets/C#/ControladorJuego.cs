using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorJuego : MonoBehaviour
{
    public List<Ronda> rondas;
    private int rondaActual;
    private int puntaje;

    // Definir evento para finalizar juego
    public event Action<bool> OnJuegoTerminado;

    void Start()
    {
        IniciarJuego();
    }

    void IniciarJuego()
    {
        // Inicializar rondas y otros elementos del juego
    }

    void FinalizarJuego(bool victoria)
    {
        // Manejar la l�gica de finalizaci�n del juego
        OnJuegoTerminado?.Invoke(victoria);
    }

    void ManejarCliente()
    {
        // L�gica para manejar la llegada de un cliente
    }
}
