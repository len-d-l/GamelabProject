using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PollenAbility : MonoBehaviour
{
    public float healAmount;
    public GameObject pollenParticle;
    private GameObject player;

    public float fadeOutTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void AbilityStart()
    {
        StartCoroutine(AbilitySequence());
    }

    private IEnumerator AbilitySequence()
    {
        yield return new WaitForSeconds(0.25f);
        pollenParticle.SetActive(true);
        CheckForAllies();
        yield return new WaitForSeconds(3f);
        pollenParticle.SetActive(false);
    }

    private void CheckForAllies()
    {
        Collider[] colliders = Physics.OverlapSphere(player.transform.position, 4f);
        foreach (Collider c in colliders)
        {
            if (c.GetComponent<PlayerStats>())
            {
                c.GetComponent<PlayerStats>().HealPlayer(20);
                
            }
        }
    }
}
