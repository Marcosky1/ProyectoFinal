using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "AudioSettings", menuName = "ScriptableObjects/AudioSettings", order = 1)]
public class AudioSettings : ScriptableObject
{
    public float musicVolume = 1f;
    public float sfxVolume = 1f;
}
