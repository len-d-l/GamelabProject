using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootHoney : MonoBehaviour
{
    public GameObject honeyBallPrefab; // Reference to the honey ball prefab
    public Transform shootPoint;       // Point from which the honey ball will be shot
    public float shootForce = 500f;    // Force with which the honey ball will be shot

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Assuming left mouse button for shooting
        {
            ShootHoneyBall();
        }
    }

    void ShootHoneyBall()
    {
        GameObject honeyBall = Instantiate(honeyBallPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = honeyBall.GetComponent<Rigidbody>();
        rb.AddForce(shootPoint.forward * shootForce);
    }
}
