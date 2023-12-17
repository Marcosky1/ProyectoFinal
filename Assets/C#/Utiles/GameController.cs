using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameData gameData;
    public UIManager uiManager;
    public Image estrellasImage;
    public Text puntosText;
    public float tiempoActualizacionPuntos = 1f;
    private float tiempoTranscurridoPuntos = 0f;


    void Update()
    {
        tiempoTranscurridoPuntos += Time.deltaTime;
        if (tiempoTranscurridoPuntos >= tiempoActualizacionPuntos)
        {
            ActualizarPuntos();
            tiempoTranscurridoPuntos = 0f;
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

    void ActualizarPuntos()
    {
        puntosText.text = "Dinero: s/ " + gameData.puntos;
    }

    public void SumarPuntos(int cantidad)
    {
        gameData.puntos += cantidad;

        puntosText.text = "1Dinero: s/ " + gameData.puntos;

    }

    bool LlegoALaRondaFinal()
    {
        return gameData.rondaActual >= 5;
    }

    public void ActualizarEstrellas()
    {
        if (estrellasImage.fillAmount <= 0)
        {
            uiManager.MostrarDerrota();
        }
    }

    void OnEnable()
    {
        Cliente.OnClienteAtendido += ClienteAtendido;
        Cliente.OnTiempoAgotado += TiempoAgotado;
    }

    void OnDisable()
    {
        Cliente.OnClienteAtendido -= ClienteAtendido;
        Cliente.OnTiempoAgotado -= TiempoAgotado;
    }

    void ClienteAtendido(bool esPreferencial)
    {
        if (esPreferencial)
        {
            gameData.puntos += 2;
            estrellasImage.fillAmount += 0.4f;
        }
    }

    void TiempoAgotado(bool esPreferencial)
    {
        if (esPreferencial)
        {
            estrellasImage.fillAmount -= 0.2f;
        }
    }
}

