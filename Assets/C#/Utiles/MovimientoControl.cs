using UnityEngine;

public class MovimientoControl : MonoBehaviour
{
    public Transform[] nodos;  // Los nodos que forman la ruta
    public float velocidad = 5f;  
    public float aceleracion = 2f;  

    private int indiceNodoActual = 0;  // Índice del nodo actual
    private float tiempoInicioMovimiento; 
    private float distanciaRecorrida;  // Distancia recorrida en el movimiento MRUV

    private Animator anim;

    void Start()
    {
        tiempoInicioMovimiento = Time.time;
        transform.position = nodos[indiceNodoActual].position;
    }

    void Update()
    {
        MoverNodo();
    }

    void MoverNodo()
    {
        // Calcular la distancia recorrida en el movimiento MRUV
        distanciaRecorrida = velocidad * (Time.time - tiempoInicioMovimiento) +
                            0.5f * aceleracion * Mathf.Pow(Time.time - tiempoInicioMovimiento, 2);

        // Mover hacia el siguiente nodo
        transform.position = Vector3.MoveTowards(transform.position, nodos[indiceNodoActual].position, distanciaRecorrida * Time.deltaTime);

        // Si llegamos al nodo, avanzamos al siguiente
        if (transform.position == nodos[indiceNodoActual].position)
        {
            tiempoInicioMovimiento = Time.time;
            indiceNodoActual = (indiceNodoActual + 1) % nodos.Length;
        }
    }
}
