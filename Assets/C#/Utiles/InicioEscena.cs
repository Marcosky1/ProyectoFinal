using UnityEngine;
using TMPro;

public class InicioEscena : MonoBehaviour
{
    public GameData gameData;
    public TMP_Text textoPuntosUI;
    public TMP_Text textoRondasUI;

    void Start()
    {
        ActualizarTextoUI();

        ReiniciarDatos();       
    }


    void ActualizarTextoUI()
    {
        if (textoPuntosUI != null)
        {
            textoPuntosUI.text = "Rondas superadas : " + gameData.puntos;
        }

        if (textoRondasUI != null)
        {
            textoRondasUI.text = "Dinero recaudado : s/" + gameData.rondaActual;
        }
    }

    void ReiniciarDatos()
    {
        GuardarDatos();

        gameData.puntos = 0;
        gameData.rondaActual = 1;
    }

    void GuardarDatos()
    {
        PlayerPrefs.SetInt("Puntos", gameData.puntos);
        PlayerPrefs.SetInt("Rondas", gameData.rondaActual);
        PlayerPrefs.Save(); 
    }

}
