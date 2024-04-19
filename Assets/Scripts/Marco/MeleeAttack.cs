using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float attackRange = 2f; // Range of the melee attack
    public LayerMask attackLayer; // Layer mask to filter which objects can be attacked
    public int damage = 10; // Damage inflicted by the melee attack

    void Update()
    {
        // Check if left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            PerformMeleeAttack(); // Call the PerformMeleeAttack method
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
   
}
