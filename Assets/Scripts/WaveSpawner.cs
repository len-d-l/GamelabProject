using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public TextMeshProUGUI waveCountText;
    int waveCount = 1;
    
    public float spawnRate = 1.0f;
    public float timeBetweenWaves = 3.0f;

    public int enemyCount;

    public GameObject enemy;

    bool waveIsDone = true;


    void Update()
    {
        waveCountText.text = "Wave " + waveCount.ToString();

        if (waveIsDone == true)
        {
            StartCoroutine(waveSpawner());
        }
    }

    IEnumerator waveSpawner()
    {

        waveIsDone = false;
        

        for (int i = 0; i < enemyCount; i++)
            {
            Vector3 randoPos = new Vector3(Random.Range(3, 10), 1, Random.Range(3, 10));
            GameObject enemyClone = Instantiate(enemy, this.transform.position + randoPos, Quaternion.identity);

            yield return new WaitForSeconds(spawnRate);
        }

        spawnRate -= 0.1f;
        enemyCount += 3;
        waveCount += 1;

        yield return new WaitForSeconds(timeBetweenWaves);

        waveIsDone = true;
    }
}
