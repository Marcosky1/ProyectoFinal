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
        public bool ocupado;
        public Vector3 posicion; 
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
        botonCrearElemento.onClick.AddListener(CrearElemento);

        CrearNodos();

        nodoActual = cabezaLista;
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
        if (elementosCreados < nodosPrefabs.Length)
        {
            // Asegurarse de que nodoActual esté inicializado
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
                    // Instanciar la hamburguesa en la posición del nodo
                    Instantiate(hamburguesaPrefab, nodoActual.posicion, Quaternion.identity);

                    // Marcar el nodo como ocupado
                    nodoActual.ocupado = true;

                    // Aumentar el contador de elementos creados
                    elementosCreados++;

                    nodoActual = nodoActual.siguiente;

                    if (elementosCreados >= nodosPrefabs.Length)
                    {
                        Debug.Log("Se han creado todos los elementos.");
                    }

                    return;
                }

                nodoActual = nodoActual.siguiente; // Avanza al siguiente nodo

            } while (nodoActual != nodoInicio); 

            Debug.Log("No hay nodos disponibles para crear elementos.");
        }
    }
}
