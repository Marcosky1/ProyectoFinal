using UnityEngine;
using UnityEngine.UI;

public class CrearElementos : MonoBehaviour
{
    public Button botonCrearElemento;
    public GameObject[] nodosPrefabs;
    public GameObject hamburguesaPrefab;

    private Nodo cabezaLista;
    private Nodo nodoActual; // Nodo actual en la lista
    private int elementosCreados = 0;

    private class Nodo
    {
        public Vector3 posicion;
        public Nodo siguiente;

        public Nodo(Vector3 pos)
        {
            posicion = pos;
            siguiente = null;
        }
    }

    void Start()
    {
        CrearNodos();
        nodoActual = cabezaLista;
        botonCrearElemento.onClick.AddListener(CrearElemento);
    }

    void CrearNodos()
    {
        if (nodosPrefabs == null || nodosPrefabs.Length == 0)
        {
            Debug.LogWarning("No se han asignado nodos. Asegúrate de asignar nodos en el Inspector.");
            return;
        }

        cabezaLista = new Nodo(nodosPrefabs[0].transform.position);
        Nodo nodoAnterior = cabezaLista;

        for (int i = 1; i < nodosPrefabs.Length; i++)
        {
            Nodo nuevoNodo = new Nodo(nodosPrefabs[i].transform.position);
            nodoAnterior.siguiente = nuevoNodo;
            nodoAnterior = nuevoNodo;
        }

        // Hacer la lista circular conectando el último nodo al primero
        nodoAnterior.siguiente = cabezaLista;
    }

    void CrearElemento()
    {
        // Instanciar la hamburguesa en la posición del nodo
        Instantiate(hamburguesaPrefab, nodoActual.posicion, Quaternion.identity);

        // Aumentar el contador de elementos creados
        elementosCreados++;

        nodoActual = nodoActual.siguiente;

        if (elementosCreados >= nodosPrefabs.Length)
        {
            Debug.Log("Se han creado todos los elementos.");
        }
    }
}
