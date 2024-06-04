using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollenAbility : MonoBehaviour
{
    public float healAmount;
    public ParticleSystem pollenParticle;

    public bool isReady = true;
    public float cooldownTime = 4f;

    public float fadeOutTime = 4f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UseAbility();
        }
    }

    private void UseAbility()
    {
        if (isReady == false)
        {
            return;
        }

        SpawnPollen(Color.yellow);
        StartCoroutine(AbilitySequence());
    }

    private IEnumerator AbilitySequence()
    {
        isReady = false;
        CheckForAllies();
        yield return new WaitForSeconds(cooldownTime);
        isReady = true;
    }

    private void CheckForAllies()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 4f);
        foreach (Collider c in colliders)
        {
            if (c.GetComponent<PlayerStats>())
            {
                c.GetComponent<PlayerStats>().HealPlayer(healAmount);
                Debug.Log("Healed");
            }
        }
    }

    public void SpawnPollen(Color color)
    {
        ParticleSystem particle = Instantiate(pollenParticle, transform.position, Quaternion.identity);
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