using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DatosCoccion", menuName = "Juego/DatosCoccion")]
public class DatosCoccion : ScriptableObject
{
    public Color colorCrudo;
    public Color colorCocido;
    public Color colorQuemado;

    public float tiempoCoccionCocido;
    public float tiempoCoccionQuemado;
}
