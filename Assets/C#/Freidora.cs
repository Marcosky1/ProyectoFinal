using UnityEngine;
using System.Collections.Generic;
using System;


public class Freidora : MonoBehaviour
{
    public Queue<Comida> colaFritura;

    // Definir evento para freír comida
    public event Action OnComidaFrita;

    void Freir()
    {
        // Lógica para freír comida en la freidora
        OnComidaFrita?.Invoke();
    }
}
