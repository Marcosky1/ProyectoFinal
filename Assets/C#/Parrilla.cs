using UnityEngine;
using UnityEngine.UI;

public class Parrilla : MonoBehaviour
{
    public DatosCoccion datosCoccion;
    public Image barraDeCoccion;

    private float tiempoCoccion = 0f;

    void Start()
    {
        IniciarCoccion();
    }

    void Update()
    {
        tiempoCoccion += Time.deltaTime;

        ActualizarBarraDeCoccion();

        CambiarColorSegunCoccion();

        VerificarCoccionCompleta();
    }

    void IniciarCoccion()
    {
        tiempoCoccion = 0f;

        barraDeCoccion.fillAmount = 0f;
    }

    void ActualizarBarraDeCoccion()
    {
        float progreso = tiempoCoccion / datosCoccion.tiempoCoccionQuemado;

        progreso = Mathf.Clamp01(progreso);

        barraDeCoccion.fillAmount = progreso;
    }

    void CambiarColorSegunCoccion()
    {
        Color colorCoccion = Color.Lerp(datosCoccion.colorCrudo, datosCoccion.colorQuemado, barraDeCoccion.fillAmount);

        barraDeCoccion.color = colorCoccion;
    }

    void VerificarCoccionCompleta()
    {
        if (barraDeCoccion.fillAmount == 1f || tiempoCoccion > (datosCoccion.tiempoCoccionQuemado + 10f))
        {
            if (barraDeCoccion.fillAmount == 1f)
            {
                Debug.Log("La carne está completamente cocida.");
            }
            else
            {
                Debug.Log("La carne se ha quemado.");
            }
            Destroy(gameObject);
        }
    }
}




