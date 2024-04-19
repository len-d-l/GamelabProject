using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumbleBeeAbilities : MonoBehaviour
{
    public GameObject healthPrefab;

    public ParticleSystem pollen;

    public float fadeOutTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // Change KeyCode.Space to the desired button
        {
            SpawnPollen(Color.yellow); // Change color as per your 
            SpawnHealing();
        }
    }

    public void SpawnPollen(Color color)
    {
        ParticleSystem particle = Instantiate(pollen, transform.position, Quaternion.identity);
        var mainModule = particle.main;
        mainModule.startColor = color;

        // Start fading out the particle system
        StartCoroutine(FadeOut(particle, fadeOutTime));
    }
    void SpawnHealing()
    {
        Instantiate(healthPrefab, transform.position, Quaternion.identity);
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
