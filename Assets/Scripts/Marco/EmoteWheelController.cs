using UnityEngine;
using System.Collections;

public class EmoteWheelController : MonoBehaviour
{
    public GameObject emoteWheel;
    private ParticleSystem selectedParticleSystem;
    private Transform playerTransform;
    public float fadeOutTime;

    void Update()
    {
        if (playerTransform == null)
        {
            // Try to find the player transform if it's not set
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerTransform = player.transform;
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            emoteWheel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            emoteWheel.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        // Check for Shift key press to spawn the selected particle system
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            SpawnSelectedParticleSystem();
        }
    }

    public void SpawnSelectedParticleSystem()
    {
        if (selectedParticleSystem != null && playerTransform != null)
        {
            // Instantiate the particle system at the player's position
            ParticleSystem instantiatedParticle = Instantiate(selectedParticleSystem, playerTransform.position, Quaternion.identity);

            // Start the fade-out coroutine with the instantiated particle system
            StartCoroutine(FadeOut(instantiatedParticle, fadeOutTime));
        }
    }

    IEnumerator FadeOut(ParticleSystem particle, float fadeTime)
    {
        float currentTime = 0f;
        float startSize = particle.main.startSize.constant;

        while (currentTime < fadeTime)
        {
            currentTime += Time.deltaTime;

            // Calculate the interpolation factor
            float factor = Mathf.Clamp01(currentTime / fadeTime);

            // Interpolate the size of particles
            var mainModule = particle.main;
            mainModule.startSize = Mathf.Lerp(startSize, 0f, factor);

            yield return null;
        }
        Debug.Log("Spawned");
        // After the fade-out, stop the particle system
        particle.Stop();

        // Wait for a short time to ensure particles have finished emitting
        yield return new WaitForSeconds(particle.main.startLifetime.constant);

        // Destroy the particle system game object
        Destroy(particle.gameObject);
    }

    // Method to set the selected particle system
    public void SetSelectedParticleSystem(ParticleSystem particleSystem)
    {
        selectedParticleSystem = particleSystem;
    }
}
