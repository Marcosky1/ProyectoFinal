using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text puntosText;

    private string WinScene = "Win";
    private string GameOverScene = "GameOver";

    public void ActualizarPuntos(int puntos)
    {
        puntosText.text = "Dinero: s/" + puntos;
    }

    public void MostrarVictoria()
    {
        SceneManager.LoadScene(WinScene);
    }

    public void MostrarDerrota()
    {
        SceneManager.LoadScene(GameOverScene);
    }
}



