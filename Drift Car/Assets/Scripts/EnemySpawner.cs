using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float nextSpawnTime;

    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float spawnDelay = 10;

    private void Update()
    {
        if(ShouldSpawn())
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        nextSpawnTime = Time.time + spawnDelay;
        Instantiate(enemyPrefab, transform.position, transform.rotation);

    }
    
    private bool ShouldSpawn()
    {
        return Time.time >= nextSpawnTime;
    }


}