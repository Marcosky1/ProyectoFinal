using UnityEngine;

[CreateAssetMenu(fileName = "NuevaComida", menuName = "Juego/Comida")]
public class TipoComida : ScriptableObject
{
    public string nombre;
    public float tiempoCoccion;
    // Agrega otras propiedades según tus necesidades.
}
