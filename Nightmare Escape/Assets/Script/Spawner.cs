using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;

    void Start()
    {
        SpawnEnemy();
    }


    public void SpawnEnemy()
    {
        Instantiate(enemy, new Vector3(transform.position.x + Random.Range(0,5), transform.position.y, transform.position.z+ Random.Range(0,5)), Quaternion.identity);
        
    }
}
