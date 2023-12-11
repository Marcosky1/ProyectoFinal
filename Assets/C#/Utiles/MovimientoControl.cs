using UnityEngine;

public class MovimientoControl : MonoBehaviour
{
    public NodoLista primerNodo;  
    public float velocidad = 5f;
    public float aceleracion = 2f;
    public float smoothTime = 0.3f;  

    private NodoLista nodoActual;  
    private float tiempoInicioMovimiento;
    private Vector3 velocidadSmoothDamp;

    private Animator anim;

    void Start()
    {
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

        // Calcular la posición objetivo del nodo
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
}

public class NodoLista
{
    public Vector3 position;   
    public NodoLista siguienteNodo;  
}
