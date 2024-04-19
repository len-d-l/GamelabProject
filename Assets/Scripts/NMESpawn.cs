using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NMESpawn : MonoBehaviour
{
    public GameObject enemyHere;
    public int x;
    public int y;
    public int z;
    

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyHere, new Vector3(x, y, z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
