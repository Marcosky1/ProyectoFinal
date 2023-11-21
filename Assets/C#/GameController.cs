using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameData gameData;
    public UIManager uiManager;

    void Update()
    {
        if (gameData.victoria)
        {
            uiManager.MostrarVictoria();
        }
        else if (PerdioJuego())
        {
            uiManager.MostrarDerrota();
        }
    }

    bool PerdioJuego()
    {
        if (gameData.puntos <= 0 || LlegoALaRondaFinal())
        {
            return true;
        }

        return false;
    }

    bool LlegoALaRondaFinal()
    {
        return gameData.rondaActual >= 20;
    }

}

