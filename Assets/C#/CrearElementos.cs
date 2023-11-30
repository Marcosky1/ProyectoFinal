using UnityEngine;
using UnityEngine.UI;

public class CrearElementos : MonoBehaviour
{
    public Button botonCrearElemento; // Bot�n para crear elementos
    public GameObject[] nodosPrefabs; // Array de Prefabs de nodos
    public GameObject hamburguesaPrefab; // Prefab de la hamburguesa

    private Nodo cabezaLista; // Cabeza de la lista
    private Nodo nodoActual; // Nodo actual en la lista
    private int elementosCreados = 0;

    // Nodo que representa un elemento en la lista
    private class Nodo
    {
        public bool ocupado;
        public Vector3 posicion; // Posici�n del nodo
        public Nodo siguiente;

        public Nodo(Vector3 pos)
        {
            ocupado = false;
            posicion = pos;
            siguiente = null;
        }
    }

    void Start()
    {
        // Configuraci�n del bot�n
        botonCrearElemento.onClick.AddListener(CrearElemento);

        // Configuraci�n de los nodos
        CrearNodos();

        // Inicializar nodoActual al inicio
        nodoActual = cabezaLista;
    }

    void CrearNodos()
    {
        if (nodosPrefabs == null || nodosPrefabs.Length == 0)
        {
            Debug.LogWarning("No se han asignado nodos. Aseg�rate de asignar nodos en el Inspector.");
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

        // Hacer la lista circular conectando el �ltimo nodo al primero
        nodoAnterior.siguiente = cabezaLista;
    }

    void CrearElemento()
    {
        if (elementosCreados < nodosPrefabs.Length)
        {
            // Asegurarse de que nodoActual est� inicializado
            if (nodoActual == null)
            {
                nodoActual = cabezaLista;
            }

            // Encuentra el primer nodo no ocupado
            Nodo nodoInicio = nodoActual; // Guarda la referencia al nodo actual para evitar bucles infinitos

            do
            {
                if (!nodoActual.ocupado)
                {
                    // Instanciar la hamburguesa en la posici�n del nodo
                    Instantiate(hamburguesaPrefab, nodoActual.posicion, Quaternion.identity);

                    // Marcar el nodo como ocupado
                    nodoActual.ocupado = true;

                    // Aumentar el contador de elementos creados
                    elementosCreados++;

                    // Avanzar al siguiente nodo
                    nodoActual = nodoActual.siguiente;

                    // Verificar si se ha alcanzado el l�mite
                    if (elementosCreados >= nodosPrefabs.Length)
                    {
                        Debug.Log("Se han creado todos los elementos.");
                        // Puedes desactivar el bot�n u realizar otras acciones cuando se alcance el l�mite
                    }

                    return;
                }

                nodoActual = nodoActual.siguiente; // Avanza al siguiente nodo

            } while (nodoActual != nodoInicio); // Salir del bucle si volvemos al nodo de inicio

            Debug.Log("No hay nodos disponibles para crear elementos.");
        }
    }
}
