using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameData gameData;
    public UIManager uiManager;
    public Image estrellasImage; 

    void Update()
    {
        
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

    void ActualizarEstrellas()
    {
        // Restar 0.2 al fillAmount
        estrellasImage.fillAmount -= 0.2f;

        // Verificar si el fillAmount llego a cero
        if (estrellasImage.fillAmount <= 0)
        {
            uiManager.MostrarDerrota();
        }
    }
}

