using UnityEngine;
using UnityEngine.UI;

public class TableroPuntajes : MonoBehaviour
{
    public Text[] textosPuntajes; 

    public void MostrarPuntajesOrdenados()
    {
        // acceso a la instancia de GameData
        GameData gameData = FindObjectOfType<GameData>();

        if (gameData != null)
        {
            gameData.OrdenarHistorialNodos();

            GameData.Nodo nodoActual = gameData.cabeza;

            for (int i = 0; i < textosPuntajes.Length && nodoActual != null; i++)
            {
                textosPuntajes[i].text = "Puntos = " + nodoActual.puntos + " -  Rondas" + nodoActual.ronda;
                nodoActual = nodoActual.siguiente;
            }
        }
    }
}

