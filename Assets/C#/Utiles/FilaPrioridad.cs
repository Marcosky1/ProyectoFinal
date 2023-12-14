using System.Collections;
using UnityEngine;
using System;

public class NodoCliente
{
    public Transform ClientePrefab;
    public NodoCliente Siguiente;

    public NodoCliente(Transform clientePrefab)
    {
        ClientePrefab = clientePrefab;
        Siguiente = null;
    }
}

public class FilaPrioridad: MonoBehaviour
{
    protected NodoCliente cabeza;

    public void AgregarCliente(Transform clientePrefab)
    {
        NodoCliente nuevoNodo = new NodoCliente(clientePrefab);
        nuevoNodo.Siguiente = cabeza;
        cabeza = nuevoNodo;
        ActualizarPosiciones();
    }

    public void EliminarCliente()
    {
        if (cabeza != null)
        {
            Transform cliente = cabeza.ClientePrefab;
            cabeza = cabeza.Siguiente;
            GameObject.Destroy(cliente.gameObject);
            ActualizarPosiciones();
        }
    }

    public void VaciarFila()
    {
        while (cabeza != null)
        {
            Transform cliente = cabeza.ClientePrefab;
            cabeza = cabeza.Siguiente;
            GameObject.Destroy(cliente.gameObject);
        }
    }

    public int CantidadClientesEnFila()
    {
        int contador = 0;
        NodoCliente actual = cabeza;
        while (actual != null)
        {
            contador++;
            actual = actual.Siguiente;
        }
        return contador;
    }

    protected virtual void ActualizarPosiciones()
    {
        NodoCliente actual = cabeza;
        int index = 0;
        while (actual != null)
        {
            float yPos = index * 2f; // Ajusta la separacion vertical
            actual.ClientePrefab.position = new Vector3(0f, yPos, 0f);
            actual = actual.Siguiente;
            index++;
        }
    }
}

public class GeneradorClientes : FilaPrioridad
{
    public GameObject clientePrefab;
    public GameObject clientePreferencialPrefab;
    public GameData gameData;

    private float ProbabilidadClientePreferencial = 0.2f;

    private void Update()
    {
        StartCoroutine(GenerarClientes());
    }

    private IEnumerator GenerarClientes()
    {
        yield return new WaitForSeconds(2f);

        // Decide si el siguiente cliente será preferencial o no
        GameObject nuevoClientePrefab = (UnityEngine.Random.value < ProbabilidadClientePreferencial) ? clientePreferencialPrefab : clientePrefab;


        GameObject nuevoCliente = Instantiate(nuevoClientePrefab, transform.position, Quaternion.identity);
        AgregarCliente(nuevoCliente.transform);

        if (CantidadClientesEnFila() >= 4)
        {
            gameData.AumentarRonda();
            VaciarFila();
        }
    }

    protected override void ActualizarPosiciones()
    {
        NodoCliente actual = cabeza;
        int index = 0;
        while (actual != null)
        {
            float yPos = index * 2f;
            actual.ClientePrefab.position = new Vector3(0f, yPos, 0f);
            actual = actual.Siguiente;
            index++;
        }
    }
}
