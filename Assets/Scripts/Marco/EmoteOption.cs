using UnityEngine;

public class EmoteOption : MonoBehaviour
{
    public ParticleSystem particleEffect;  // Assign the Particle System in the Inspector
    private EmoteWheelController emoteWheelController;  // Reference to the EmoteWheelController

    void Start()
    {
        // Find the EmoteWheelController in the scene
        emoteWheelController = FindObjectOfType<EmoteWheelController>();
    }

    public void OnOptionSelected()
    {
        if (particleEffect != null && emoteWheelController != null)
        {
            emoteWheelController.SetSelectedParticleSystem(particleEffect);
        }
    }
}
