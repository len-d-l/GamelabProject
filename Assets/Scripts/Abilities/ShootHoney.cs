using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootHoney : MonoBehaviour
{
    public GameObject honeyBallPrefab; // Reference to the honey ball prefab
    public Transform shootPoint;       // Point from which the honey ball will be shot
    public float shootForce = 500f;    // Force with which the honey ball will be shot

    public bool isReady = true;
    public float cooldownTime = 4f;

    private bool hasFired = false;

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

    void ShootHoneyBall()
    {
        GameObject honeyBall = Instantiate(honeyBallPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = honeyBall.GetComponent<Rigidbody>();
        rb.AddForce(shootPoint.forward * shootForce);
    }

    private IEnumerator AbilitySequence()
    {
        isReady = false;
        if (!hasFired)
        {
            hasFired = true;

            ShootHoneyBall();
        }
        hasFired = false;
        yield return new WaitForSeconds(cooldownTime);
        isReady = true;
    }
}
