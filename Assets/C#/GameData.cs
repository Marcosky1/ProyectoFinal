using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 1)]
public class GameData : ScriptableObject
{
    public int puntos;
    public int puntosMaximos;
    public bool victoria;
    public int rondaActual { get; set; }
}

