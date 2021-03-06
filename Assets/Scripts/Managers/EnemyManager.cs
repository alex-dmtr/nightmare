﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 10f;
    public Transform[] spawnPoints;
    public LevelContainer levelContainer;
    private int level;
    public float minSpawnTime = 4f;

    void Start()
    {
        level = levelContainer.GetLevel();
        InvokeRepeating("Spawn", spawnTime, spawnTime);
   
    }
    
    void Spawn ()
    {
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }
        if(level < levelContainer.GetLevel() && spawnTime > minSpawnTime)
        {
            level = levelContainer.GetLevel();
            CancelInvoke("Spawn");
            spawnTime = spawnTime - (spawnTime * 25 / 100);
            InvokeRepeating("Spawn", spawnTime, spawnTime);
        }else {

            var okSpawnPoints = spawnPoints.Where(point =>
            {
                var distance = Vector3.Distance(point.position, playerHealth.transform.position);

                var RADIUS = 15f;
                var MAXRADIUS = 25f;
                return (distance >= RADIUS && distance <= MAXRADIUS);
            }).ToArray();

            if (okSpawnPoints.Length == 0)
                // okSpawnPoints = spawnPoints;
                return;
          
            int spawnPointIndex = Random.Range (0, okSpawnPoints.Length);

            Instantiate (enemy, okSpawnPoints[spawnPointIndex].position, okSpawnPoints[spawnPointIndex].rotation);
        }
        
    }
}
