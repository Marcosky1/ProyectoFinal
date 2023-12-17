using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorParticulas : MonoBehaviour
{
    public ParticleSystem particulasParrilla;
    public ParticleSystem particulasFreidora;
    public ParticleSystem particulasOtro;
    public AudioSource audioSourceF;
    public AudioSource audioSourcePA;
    public AudioSource audioSourcePO;
    

    private void Start()
    {
        
    }

    public void OnParrillaAction(InputAction.CallbackContext ctx)
    {
        ToggleParticulas(particulasParrilla, audioSourceF);
    }

    public void OnFreidoraAction(InputAction.CallbackContext ctx)
    {
        ToggleParticulas(particulasFreidora, audioSourcePA);
    }

    public void OnOtroAction(InputAction.CallbackContext ctx)
    {
        ToggleParticulas(particulasOtro, audioSourcePO);
    }

    private void ToggleParticulas(ParticleSystem particulas, AudioSource audio)
    {
        if (particulas.isPlaying)
        {
            particulas.Stop();
            audio.Pause();
        }
        else
        {
            particulas.Play();
            audio.Play();
        }
    }
}
