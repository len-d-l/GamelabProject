using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyBall : MonoBehaviour
{
    public GameObject honeySpreadPrefab; // Reference to the honey spread prefab

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Assuming the ground has the tag "Ground"
        {
            Instantiate(honeySpreadPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
