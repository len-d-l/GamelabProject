using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HoneySpread : MonoBehaviour
{
    public float slowSpeed = 1;
    public float despawnTime = 4f;

    private List <NavMeshAgent> agent = new List<NavMeshAgent>();

    private void Start()
    {
        StartCoroutine(DespawnHoney());
    }

    private void OnTriggerEnter(Collider other)
    {
        agent.Add(other.GetComponent<NavMeshAgent>());
        NavMeshAgent navMeshAgent = other.GetComponent<NavMeshAgent>();

        if (agent.Contains(navMeshAgent))
        {

            if (navMeshAgent != null)
            {
                navMeshAgent.speed -= slowSpeed;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        NavMeshAgent navMeshAgent = other.GetComponent<NavMeshAgent>();

        if (agent.Contains(navMeshAgent))
        {
            agent.Remove(navMeshAgent);

            if (navMeshAgent != null)
            {
                navMeshAgent.speed += slowSpeed;
            }
        }
    }

    private IEnumerator DespawnHoney()
    {
        yield return new WaitForSeconds(despawnTime);
        foreach (NavMeshAgent agent in agent)
        {
            if (agent != null)
            {
                agent.speed += slowSpeed;
            }
        }
        Destroy(gameObject);
    }
}
