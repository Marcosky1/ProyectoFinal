using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;  
    public Slider musicSlider;    
    public Slider sfxSlider;     
    public AudioSettings audioSettings; 

    private const string musicVolumeParameter = "MusicVolume";  
    private const string sfxVolumeParameter = "SFXVolume";     

    private void Start()
    {
        SetInitialSliderValues();
    }

    private void SetInitialSliderValues()
    {
        if (audioMixer != null && audioSettings != null)
        {

            float musicVolume = audioSettings.musicVolume;
            float sfxVolume = audioSettings.sfxVolume;

            musicSlider.value = musicVolume;
            sfxSlider.value = sfxVolume;

            SetMusicVolume(musicVolume);
            SetSFXVolume(sfxVolume);
        }
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat(musicVolumeParameter, Mathf.Log10(volume) * 20);
        audioSettings.musicVolume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat(sfxVolumeParameter, Mathf.Log10(volume) * 20);
        audioSettings.sfxVolume = volume;
    }
}
