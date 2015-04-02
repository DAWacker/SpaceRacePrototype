using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class ObstacleManager : MonoBehaviour
{
    List<Obstacle> obstacles;
    float[] locations = new float[] { -3.0f, 0.0f, 3.0f };
    System.Random rand;

    float timeSinceLastSpawn;
    float spawnDelay;

    void Start()
    {
        // Gather all platforms in the scene
        obstacles = FindObjectsOfType<Obstacle>().ToList();

        rand = new System.Random();

        timeSinceLastSpawn = 0.0f;
        spawnDelay = 0.25f;
    }

    void SpawnObstacle()
    {
        Obstacle obstacle = obstacles.FirstOrDefault(o => !o.IsActive);

        if (obstacle)
        {
            float newLocationX = locations[rand.Next(0, 3)];

            if (obstacle)
            {
                obstacle.transform.position = new Vector3(newLocationX, 0.5f, 20.0f);
                obstacle.IsActive = true;
            }
        }
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnDelay)
        {
            timeSinceLastSpawn = 0.0f;
            SpawnObstacle();
        }
    }
}