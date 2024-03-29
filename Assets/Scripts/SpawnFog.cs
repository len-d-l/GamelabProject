using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnFog : MonoBehaviour
{
    public ParticleSystem particlePrefab;
    public float fadeOutTime; // Duration of fade-out effect

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // Change KeyCode.Space to the desired button
        {
            SpawnParticle(Color.green); // Change color as per your requirements
        }

        if (Input.GetKeyDown(KeyCode.G)) // Change KeyCode.Space to the desired button
        {
            SpawnParticle(Color.blue); // Change color as per your requirements
        }
        // Add more conditions for other buttons if needed
    }

    void SpawnParticle(Color color)
    {
        ParticleSystem particle = Instantiate(particlePrefab, transform.position, Quaternion.identity);
        var mainModule = particle.main;
        mainModule.startColor = color;

        // Start fading out the particle system
        StartCoroutine(FadeOut(particle, fadeOutTime));
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

        // After the fade-out, stop the particle system
        particle.Stop();

        // Wait for a short time to ensure particles have finished emitting
        yield return new WaitForSeconds(particle.main.startLifetime.constant);

        // Destroy the particle system game object
        Destroy(particle.gameObject);
    }
}