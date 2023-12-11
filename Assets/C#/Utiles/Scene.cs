using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public GameData gameData;

    public void IrAlJuego()
    {
        SceneManager.LoadScene("Game");
    }

    public void IrAlMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void IrAlInicio()
    {
        SceneManager.LoadScene("PantallaInicial");
    }

    public void IrAlPuntaje()
    {
        SceneManager.LoadScene("Puntaje");
    }
}

