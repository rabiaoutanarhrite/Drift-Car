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

    private GameObject player;

    private void Start()
    {
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            if (ShouldSpawn())
            {
                Spawn();
            }
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