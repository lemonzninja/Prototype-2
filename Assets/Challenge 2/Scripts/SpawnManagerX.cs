using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;
    
    private float minSpawnInterval = 3.0f;
    private float maxSpawnInterval = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(ScheduleNextSpawn), startDelay);
    }

    private void ScheduleNextSpawn()
    {
        float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        Invoke(nameof(SpawnRandomBall), spawnInterval);
    }
    
    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        
        // Generate a random index between 0 and the length of the array
        int index = Random.Range(0, ballPrefabs.Length);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[index], spawnPos, ballPrefabs[index].transform.rotation);
        
        // Schedule next spawn
        ScheduleNextSpawn();
    }
}