using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyBall : MonoBehaviour
{
    public GameObject honeySpreadPrefab; // Reference to the honey spread prefab

    private bool hasSpread = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Assuming the ground has the tag "Ground"
        {
            if (!hasSpread)
            {
                Instantiate(honeySpreadPrefab, transform.position, Quaternion.identity);

                hasSpread = true;
            }
            
            Destroy(gameObject);
        }
    }
}
