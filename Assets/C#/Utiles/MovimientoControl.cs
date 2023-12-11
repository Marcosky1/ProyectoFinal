using UnityEngine;

public class MovimientoControl : MonoBehaviour
{
    public GameObject[] nodosGameObject;  // Array de GameObjects que representan los nodos
    public float velocidad = 5f;
    public float aceleracion = 2f;
    public float smoothTime = 0.3f;

    private NodoLista[] nodos;  // Array de nodos enlazados
    private NodoLista primerNodo;
    private NodoLista nodoActual;
    private float tiempoInicioMovimiento;
    private Vector3 velocidadSmoothDamp;

    private Animator anim;

    void Start()
    {
        CrearListaEnlazada();
        tiempoInicioMovimiento = Time.time;
        transform.position = primerNodo.position;
        nodoActual = primerNodo;
    }

    void Update()
    {
        MoverNodo();
    }

    void MoverNodo()
    {
        float distanciaRecorrida = velocidad * (Time.time - tiempoInicioMovimiento) + 0.5f * aceleracion * Mathf.Pow(Time.time - tiempoInicioMovimiento, 2);

        Vector3 posicionObjetivo = nodoActual.position;

        Vector3 nuevaPosicion = Vector3.SmoothDamp(transform.position, posicionObjetivo, ref velocidadSmoothDamp, smoothTime, Mathf.Infinity, Time.deltaTime);

        transform.position = nuevaPosicion;

        if (Vector3.Distance(transform.position, posicionObjetivo) < 0.01f)
        {
            tiempoInicioMovimiento = Time.time;
            nodoActual = nodoActual.siguienteNodo;

            if (nodoActual == null)
            {
                nodoActual = primerNodo;
            }
        }
    }

    void CrearListaEnlazada()
    {
        // Inicializar la lista enlazada con los GameObjects que representan los nodos
        nodos = new NodoLista[nodosGameObject.Length];

        // Crear nodos a partir de los GameObjects
        for (int i = 0; i < nodosGameObject.Length; i++)
        {
            nodos[i] = new NodoLista(nodosGameObject[i].transform);
        }

        // Enlazar los nodos en un bucle
        for (int i = 0; i < nodos.Length - 1; i++)
        {
            nodos[i].siguienteNodo = nodos[i + 1];
        }

        // Establecer el bucle, conectando el último nodo al primer nodo
        nodos[nodos.Length - 1].siguienteNodo = nodos[0];

        // Establecer el primer nodo
        primerNodo = nodos[0];
    }
}

public class NodoLista
{
    public Vector3 position;
    public NodoLista siguienteNodo;

    public NodoLista(Transform nodoTransform)
    {
        position = nodoTransform.position;
        siguienteNodo = null;
    }
}
