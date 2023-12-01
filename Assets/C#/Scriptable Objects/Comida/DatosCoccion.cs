using UnityEngine;

[CreateAssetMenu(fileName = "DatosCoccion", menuName = "Juego/DatosCoccion")]
public class DatosCoccion : ScriptableObject
{
    public float tiempoCoccionCocido;
    public float tiempoCoccionQuemado;

    [SerializeField] private Material ColorCoccion;
    [SerializeField] private Color[] Color;

    public void ChangeEmissionColor(EtapasCoccion typeChange)
    {
        switch (typeChange)
        {
            case EtapasCoccion.Crudo:
                ColorCoccion.SetColor("_emissionColor", Color[0]);
                break;
            case EtapasCoccion.Quemado:
                ColorCoccion.SetColor("_emissionColor", Color[1]);
                break;
        }
    }
    public enum EtapasCoccion
    {
        Crudo, Cocido, Quemado
    }
}

