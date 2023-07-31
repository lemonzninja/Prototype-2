using UnityEngine;

namespace _Scripts
{
	public class SpawnManager : MonoBehaviour
	{
		[SerializeField] private GameObject[] animalPrefabs;
		private float spawnRangeX = 10;
		private float spawnPosZ = 20;

		private void Start()
		{
			InvokeRepeating(nameof(SpawnRandomAnimal), 2, 1.5f);
		}
		
		void SpawnRandomAnimal()
		{
			int animalIndex = Random.Range(0, animalPrefabs.Length);
            
			Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            
			Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
		}
		
		
	}
}