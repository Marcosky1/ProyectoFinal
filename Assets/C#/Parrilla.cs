using UnityEngine;
using System.Collections.Generic;
using System;

public class Parrilla : MonoBehaviour
{
    public Queue<Comida> colaCoccion;

    // Definir evento para cocinar comida
    public event Action OnComidaCocinada;

    void Cocinar()
    {
        // Lógica para cocinar comida en la parrilla
        OnComidaCocinada?.Invoke();
    }
}

