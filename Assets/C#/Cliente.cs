using UnityEngine;
using System;
using System.Collections.Generic;

public class Cliente : MonoBehaviour
{
    public List<TipoComida> pedido;
    public float paciencia;

    // Definir evento para perder paciencia
    public event Action OnPacienciaAgotada;

    void VerificarPaciencia()
    {
        // Lógica para verificar la paciencia del cliente
        if (paciencia <= 0)
        {
            OnPacienciaAgotada?.Invoke();
        }
    }
}

