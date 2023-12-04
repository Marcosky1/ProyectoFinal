using UnityEngine.UI;
using UnityEngine;
using System;

public class Parrilla : MonoBehaviour
{
    public DatosCoccion datosCoccion;
    public float tiempoVida = 30f;
    private float tiempoCoccionActual = 0f;

    void Update()
    {
        tiempoVida -= Time.deltaTime;
        tiempoCoccionActual += Time.deltaTime;

        ActualizarColorYEstado();

        if (tiempoVida <= 0f)
        {
            Destroy(gameObject);
        }
    }

    void ActualizarColorYEstado()
    {
        DatosCoccion.EtapasCoccion etapaCoccionActual;

        if (tiempoCoccionActual < datosCoccion.tiempoCoccionCocido)
        {
            // Etapa 1: Carne cruda (primer color)
            etapaCoccionActual = DatosCoccion.EtapasCoccion.Crudo;
        }
        else if (tiempoCoccionActual < datosCoccion.tiempoCoccionQuemado)
        {
            // Etapa 2: Carne cocida (sin color)
            etapaCoccionActual = DatosCoccion.EtapasCoccion.Cocido;
        }
        else
        {
            // Etapa 3: Carne quemada (segundo color)
            etapaCoccionActual = DatosCoccion.EtapasCoccion.Quemado;

            if (tiempoVida <= -5f)
            {
                Destroy(gameObject);
            }
        }

        // Obtener el color según la etapa de cocción
        Color colorActual = datosCoccion.ObtenerColor(etapaCoccionActual);

        GetComponent<SpriteRenderer>().color = colorActual;
    }
}






