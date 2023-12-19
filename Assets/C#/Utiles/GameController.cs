using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameData gameData;
    public UIManager uiManager;
    public Image estrellasImage;
    public Text puntosText;

    void Update()
    {
        ActualizarEstrellas();
        Ganar();
    }

    void ActualizarPuntos()
    {
        puntosText.text = "Dinero: s/" + gameData.puntos;
    }

    public void ClienteSatisfecho(int puntosCliente)
    {
        gameData.AumentarPuntos(puntosCliente);
        ActualizarPuntos();
    }

    public void Ganar()
    {
        if(gameData.rondaActual == 5)
        {
            uiManager.MostrarVictoria();
        }
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

    public void TiempoAgotado(bool esPreferencial)
    {
        if (esPreferencial)
        {
            estrellasImage.fillAmount -= 0.2f;
        }
        else
        {
            estrellasImage.fillAmount -= 0.2f;
        }
    }
}

