using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class HardenAbility : MonoBehaviour
{
    public bool isHardened = false;
    public bool isSlowed = false;
    public bool isReady = true;
    public float cooldownTime = 12f;

    private PlayerStats playerStats;
    private PlayerMovement playerMove;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        playerMove = GetComponent<PlayerMovement>();

        playerStats.OnDamageTaken += ReduceDamage;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isReady == false)
            {
                return;
            }

            StartCoroutine(AbilitySequence());
        }
    }

    private IEnumerator AbilitySequence()
    {
        isReady = false;
        isHardened = true;
        isSlowed = true;
        Slowed();
        FindObjectOfType<AudioManager>().PlayAudio("BeetleHarden");
        yield return new WaitForSeconds(cooldownTime / 2);
        isHardened = false;
        isSlowed = false;
        Slowed();
        yield return new WaitForSeconds(cooldownTime / 2);
        isReady = true;
    }

    private void ReduceDamage(ref float amount)
    {
        if (isHardened)
        {
            amount *= 0.5f;
        }
    }

    private void Slowed()
    {
        if (isSlowed)
        {
            playerMove.moveSpeed *= 0.5f;
        }

        else
            playerMove.moveSpeed /= 0.5f; 
    }
}
