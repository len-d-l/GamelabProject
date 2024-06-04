using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSlam : MonoBehaviour
{
    public float attackRange = 5f;
    public int damage = 20;

    public bool isReady = true;
    public float cooldownTime = 10f;

    // Update is called once per frame
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

        StartCoroutine(AbilitySequence());
    }

    private IEnumerator AbilitySequence()
    {
        isReady = false;
        PerformGroundSlam();
        yield return new WaitForSeconds(cooldownTime);
        isReady = true;
    }

    void PerformGroundSlam()
    {
        // Perform a spherecast to detect objects in the attack range
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange);

        foreach (Collider enemy in hitEnemies)
        {
            // Deal damage to enemy
            EnemyAI enemyAI = enemy.GetComponent<EnemyAI>();
            if (enemyAI != null)
            {
                enemyAI.TakeDamage(damage);
            }
        }
    }
}
