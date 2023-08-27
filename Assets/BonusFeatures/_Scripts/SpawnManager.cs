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
	    /*
	     *  - Start the SpawnRandomAnimal method every 1.5 seconds after 2 seconds.
	     *	- Start the SpawnLeftAnimal method every 1.5 seconds after 2 seconds.
	     *	- Start the SpawnRightAnimal method every 1.5 seconds after 2 seconds.
	     */
	    
	    InvokeRepeating(nameof(SpawnRandomAnimal), 2, 1.5f);
	    InvokeRepeating(nameof(SpawnLeftAnimal), 2, 1.5f);
	    InvokeRepeating(nameof(SpawnRightAnimal), 2, 1.5f);
    }

    private void SpawnRandomAnimal()
	{
		/*
		 * - Generate a random animal index.
		 * - Generate a random spawn position.
		 * - Instantiate a random animal.
		 * - Spawn the animal at the random spawn position.
		 */
		
	    var randomAnimal = UnityEngine.Random.Range(0, animalPrefabs.Length);
	    var randomXPos = UnityEngine.Random.Range(-spawnRangeX, spawnRangeX);
	    
	    var spawnPos = new Vector3(randomXPos, 0, spawnPosZ);
	    
	    Instantiate(animalPrefabs[randomAnimal], spawnPos, animalPrefabs[randomAnimal].transform.rotation);
	}

    private void SpawnLeftAnimal()
    {
	    /*
	     * Spawn animals on the left side of the screen.
	     * - Generate a random animal index.
	     * - Generate a random spawn position.
	     * - Instantiate a random animal.
	     * - Spawn the animal at the random spawn position.
	     */
	    
	    var randomAnimal = UnityEngine.Random.Range(0, animalPrefabs.Length);
	    var spawnPos = new Vector3(-sideSpawnPosX, 0, UnityEngine.Random.Range(-sideSpawnRangeZ, sideSpawnRangeZ));
	    
	    var rotation = new Vector3(0, 90, 0);
	    Instantiate(animalPrefabs[randomAnimal], spawnPos, Quaternion.Euler(rotation));
    }

    private void SpawnRightAnimal()
	{
		/*
		 * Spawn animals on the right side of the screen.
		 *  - Generate a random animal index.
		 * - Generate a random spawn position.
		 * - Instantiate a random animal.
		 * - Spawn the animal at the random spawn position.
		 */
		
	    var randomAnimal = UnityEngine.Random.Range(0, animalPrefabs.Length);
	    var spawnPos = new Vector3(sideSpawnPosX, 0, UnityEngine.Random.Range(-sideSpawnRangeZ, sideSpawnRangeZ));
	    
	    var rotation = new Vector3(0, -90, 0);
	    Instantiate(animalPrefabs[randomAnimal], spawnPos, Quaternion.Euler(rotation));
	}
}