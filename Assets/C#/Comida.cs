using UnityEngine;
using System.Collections;

public class Comida : MonoBehaviour
{
    public float tiempoCoccion;

    private bool estaCocida = false;

    void Start()
    {
        // Inicia la corrutina para el tiempo de cocci�n
        StartCoroutine(ContadorDeTiempoCoccion());
    }

    IEnumerator ContadorDeTiempoCoccion()
    {
        yield return new WaitForSeconds(tiempoCoccion);

        // Verifica si la comida est� cocida despu�s de esperar el tiempo de cocci�n
        estaCocida = true;

        // Puedes agregar aqu� m�s l�gica despu�s de la cocci�n
    }

    bool EstaCocida()
    {
        return estaCocida;
    }

    bool EstaQuemada()
    {
        // L�gica para verificar si la comida est� quemada
        if (!EstaCocida())
        {
            // Si no est� cocida, entonces est� quemada despu�s de 20 segundos
            StartCoroutine(QuemarDespuesDeTiempo(20f));
        }

        return false;
    }

    IEnumerator QuemarDespuesDeTiempo(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);

        // Verificar si la comida no est� cocida despu�s del tiempo especificado
        if (!EstaCocida())
        {
            // Agrega aqu� la l�gica para manejar la quema de la comida
            Debug.Log("�La comida est� quemada!");
        }
    }
}
