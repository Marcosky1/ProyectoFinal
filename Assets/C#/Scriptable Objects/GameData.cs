using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 1)]
public class GameData : ScriptableObject
{
    public int puntos;
    public int puntosMaximos;

    public int rondaActual = 1;
    public Nodo cabeza;
    public TableroPuntajes tableroPuntajes;

    [System.Serializable]
    public class Nodo
    {
        public int puntos;
        public int ronda;
        public Nodo siguiente;

        public Nodo(int puntos, int ronda)
        {
            this.puntos = puntos;
            this.ronda = ronda;
            this.siguiente = null;
        }
    }

    public void AumentarRonda()
    {
        rondaActual++;
    }

    public void AumentarPuntos(int cantidad)
    {
        puntos += cantidad;
    }

    public void GuardarNodoEnHistorial()
    {
        Nodo nuevoNodo = new Nodo(puntos, rondaActual);
        nuevoNodo.siguiente = cabeza;
        cabeza = nuevoNodo;
        AumentarRonda();
        AumentarPuntos(-puntos);

        tableroPuntajes?.MostrarPuntajesOrdenados();
    }

    public void OrdenarHistorialNodos()
    {
        if (cabeza == null || cabeza.siguiente == null)
        {
            return;
        }

        Nodo nodoOrdenado = null; 

        // Recorrer la lista original
        Nodo actual = cabeza;

        while (actual != null)
        {
            Nodo siguiente = actual.siguiente;

            // Insertar el nodo actual en la lista ordenada
            if (nodoOrdenado == null || actual.puntos > nodoOrdenado.puntos)
            {
                actual.siguiente = nodoOrdenado;
                nodoOrdenado = actual;
            }
            else
            {
                Nodo temp = nodoOrdenado;
                while (temp.siguiente != null && actual.puntos < temp.siguiente.puntos)
                {
                    temp = temp.siguiente;
                }
                actual.siguiente = temp.siguiente;
                temp.siguiente = actual;
            }

            actual = siguiente;
        }

        cabeza = nodoOrdenado; 
    }

}

