using UnityEngine;
using System.Collections.Generic;
using System;


public class Freidora : MonoBehaviour
{
    public Queue<Comida> colaFritura;

    // Definir evento para fre�r comida
    public event Action OnComidaFrita;

    void Freir()
    {
        // L�gica para fre�r comida en la freidora
        OnComidaFrita?.Invoke();
    }
}
