using UnityEngine;

[CreateAssetMenu(fileName = "DatosCoccion", menuName = "Juego/DatosCoccion")]
public class DatosCoccion : ScriptableObject
{
    public float tiempoCoccionCocido;
    public float tiempoCoccionQuemado;

    [SerializeField] private Color colorCrudo;
    [SerializeField] private Color colorQuemado;

    public Color ObtenerColor(EtapasCoccion etapa)
    {
        switch (etapa)
        {
            case EtapasCoccion.Crudo:
                return colorCrudo;
            case EtapasCoccion.Quemado:
                return colorQuemado;
            default:
                return Color.white; 
        }
    }

    public enum EtapasCoccion
    {
        Crudo, Cocido, Quemado
    }
}

