using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    Vector3 spawnPos;
    public float spawnRate;

    void Start()
    {
        spawnPos = transform.position;

        StartCoroutine(SpawnObstacle());
    }

    void Update()
    {
        
    }

    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            Spawn();

            yield return new WaitForSeconds(spawnRate);
        }
    }

    void Spawn()
    {
        int randObstacle = Random.Range(0, obstacles.Length);

        Instantiate(obstacles[randObstacle], spawnPos, transform.rotation);
    }
}
