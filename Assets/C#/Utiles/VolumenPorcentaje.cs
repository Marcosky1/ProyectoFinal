using UnityEngine;
using UnityEngine.UI;

public class VolumenPorcentaje : MonoBehaviour
{
    public Slider slider;
    public Text textoPorcentaje;

    void Start()
    {
        slider.onValueChanged.AddListener(ActualizarPorcentaje);
        ActualizarPorcentaje(slider.value);
    }

    public void ActualizarPorcentaje(float volumen)
    {
        int porcentaje = Mathf.RoundToInt(volumen * 100);
        textoPorcentaje.text = porcentaje + "%";
    }
}
