using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardenAbility : MonoBehaviour
{
    public bool isHardened = false;

    public bool isReady = true;
    public float cooldownTime = 12f;

    private PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
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
        yield return new WaitForSeconds(cooldownTime / 2);
        isHardened = false;
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
}
