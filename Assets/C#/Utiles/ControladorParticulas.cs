using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorParticulas : MonoBehaviour
{
    public ParticleSystem particulasParrilla;
    public ParticleSystem particulasFreidora;
    public ParticleSystem particulasOtro;

    private void Start()
    {
        
    }

    public void OnParrillaAction(InputAction.CallbackContext ctx)
    {
        ToggleParticulas(particulasParrilla);
    }

    public void OnFreidoraAction(InputAction.CallbackContext ctx)
    {
        ToggleParticulas(particulasFreidora);
    }

    public void OnOtroAction(InputAction.CallbackContext ctx)
    {
        ToggleParticulas(particulasOtro);
    }

    private void ToggleParticulas(ParticleSystem particulas)
    {
        if (particulas.isPlaying)
        {
            particulas.Stop();
        }
        else
        {
            particulas.Play();
        }
    }
}
