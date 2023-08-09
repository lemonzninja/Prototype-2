using System;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	[SerializeField] private GameObject[] animalPrefabs;
 	[SerializeField] private float spawnRangeX = 10.0f;
    [SerializeField] private float spawnPosZ = 20.0f;
    
    [SerializeField] private float sideSpawnRangeZ = 10.0f;
    [SerializeField] private float sideSpawnPosX = 10.0f;

    private void Start()
    {
	    InvokeRepeating(nameof(SpawnRandomAnimal), 2, 1.5f);
	    InvokeRepeating(nameof(SpawnLeftAnimal), 2, 1.5f);
	    InvokeRepeating(nameof(SpawnRightAnimal), 2, 1.5f);
    }
    
    void SpawnRandomAnimal()
	{
	    var randomAnimal = UnityEngine.Random.Range(0, animalPrefabs.Length);
	    var randomXPos = UnityEngine.Random.Range(-spawnRangeX, spawnRangeX);
	    
	    var spawnPos = new Vector3(randomXPos, 0, spawnPosZ);
	    
	    Instantiate(animalPrefabs[randomAnimal], spawnPos, animalPrefabs[randomAnimal].transform.rotation);
	}

    void SpawnLeftAnimal()
    {
	    int randomAnimal = UnityEngine.Random.Range(0, animalPrefabs.Length);
	    Vector3 spawnPos = new Vector3(-sideSpawnPosX, 0, UnityEngine.Random.Range(-sideSpawnRangeZ, sideSpawnRangeZ));
	    Vector3 rotation = new Vector3(0, 90, 0);
	    Instantiate(animalPrefabs[randomAnimal], spawnPos, Quaternion.Euler(rotation));
    }
    
    void SpawnRightAnimal()
	{
	    int randomAnimal = UnityEngine.Random.Range(0, animalPrefabs.Length);
	    Vector3 spawnPos = new Vector3(sideSpawnPosX, 0, UnityEngine.Random.Range(-sideSpawnRangeZ, sideSpawnRangeZ));
	    Vector3 rotation = new Vector3(0, -90, 0);
	    Instantiate(animalPrefabs[randomAnimal], spawnPos, Quaternion.Euler(rotation));
	}
}