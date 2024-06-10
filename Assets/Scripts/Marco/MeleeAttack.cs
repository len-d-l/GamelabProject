using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float attackRange = 2f; // Range of the melee attack
    public LayerMask attackLayer; // Layer mask to filter which objects can be attacked
    public int damage = 10; // Damage inflicted by the melee attack
    public bool isReady = true;
    public bool isAttacking = false;
    public float cooldownTime = 0.75f;

    void Update()
    {
        // Check if left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            if (isReady == false)
            {
                return;
            }

            StartCoroutine(AbilitySequence());
        }
    }

    void PerformMeleeAttack()
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

    //Len

    void PlayAttackSound()
    {
        string soundToPlay = "";

        if (gameObject.name == "PlayerA(Clone)")
        {
            soundToPlay = "BeeAttack";
        }
        else if (gameObject.name == "PlayerB(Clone)")
        {
            soundToPlay = "BeetleAttack";
        }

        if (!string.IsNullOrEmpty(soundToPlay))
        {
            FindObjectOfType<AudioManager>().PlayAudio(soundToPlay);
        }
    }

    private IEnumerator AbilitySequence()
    {
        isReady = false;
        isAttacking = true;
        PerformMeleeAttack();
        PlayAttackSound();
        yield return new WaitForSeconds(cooldownTime);
        isAttacking = false;
        isReady = true;
    }
}
