using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public TextMeshProUGUI waveCountText;
    int waveCount = 0;
    
    public float spawnRate = 1.0f;
    public float timeBetweenWaves;

    public int enemyCount;

    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3;

    bool waveIsDone = true;

    private void Start()
    {
        enemyCount = 3;
        StartCoroutine(waveSpawner());
    }

    void Update()
    {
        waveCountText.text = "Wave " + waveCount.ToString();

        if (waveIsDone == true)
        {
            
        }
        else
        {
            StopCoroutine(waveSpawner());
        }
    }

    IEnumerator waveSpawner()
    {



        //int finalCount;
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 randoPos = new Vector3(Random.Range(3, 10), 1, Random.Range(3, 10));
            GameObject enemyClone = Instantiate(enemy, this.transform.position + randoPos, Quaternion.identity);

            int diceroll = Random.Range(1, 6);
            if (diceroll > 3)
            {
                Vector3 randopos2 = new Vector3(Random.Range(3, 10), 1, Random.Range(3, 10));
                GameObject enemy2clone = Instantiate(enemy2, this.transform.position + randoPos, Quaternion.identity);
            }

            int dieroll = Random.Range(1, 12);
            if (dieroll > 7)
            {
                Vector3 randopos3 = new Vector3(Random.Range(3, 10), 1, Random.Range(3, 10));
                GameObject enemy3clone = Instantiate(enemy3, this.transform.position + randoPos, Quaternion.identity);
            }
            
            //finalCount = i + 1;
            //if ( finalCount == enemyCount) {
                //waveIsDone = false;
                //enemyCount += 3;
            //}
            yield return new WaitForSeconds(.1f);
        }

        spawnRate += 0.1f;

        waveCount += 1;

        yield return new WaitForSeconds(timeBetweenWaves);

        StartCoroutine(waveSpawner());
    }
}
