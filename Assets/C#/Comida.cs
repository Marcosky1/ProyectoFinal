using UnityEngine;
using System.Collections;

public class Comida : MonoBehaviour
{
    public float tiempoCoccion;

    private bool estaCocida = false;

    void Start()
    {
        // Inicia la corrutina para el tiempo de cocción
        StartCoroutine(ContadorDeTiempoCoccion());
    }

    IEnumerator ContadorDeTiempoCoccion()
    {
        yield return new WaitForSeconds(tiempoCoccion);

        // Verifica si la comida está cocida después de esperar el tiempo de cocción
        estaCocida = true;

        // Puedes agregar aquí más lógica después de la cocción
    }

    bool EstaCocida()
    {
        return estaCocida;
    }

    bool EstaQuemada()
    {
        // Lógica para verificar si la comida está quemada
        if (!EstaCocida())
        {
            // Si no está cocida, entonces está quemada después de 20 segundos
            StartCoroutine(QuemarDespuesDeTiempo(20f));
        }

        return false;
    }

    IEnumerator QuemarDespuesDeTiempo(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);

        // Verificar si la comida no está cocida después del tiempo especificado
        if (!EstaCocida())
        {
            // Agrega aquí la lógica para manejar la quema de la comida
            Debug.Log("¡La comida está quemada!");
        }
    }
}
