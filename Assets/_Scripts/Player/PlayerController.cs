using UnityEngine;

namespace _Scripts.Player
{
	public class PlayerController : MonoBehaviour
	{
		// variable to hold the projectile "Food" prefab
		[SerializeField] private GameObject foodPrefab;
		
		[SerializeField] private GameObject shotPrefabFrom;
		
		// player movement variables
		public float horizontalInput;
		public float speed = 10.0f;
		public float xRange = 10.0f;
        
		private void Update()
		{
			// player movement
			horizontalInput = Input.GetAxis("Horizontal");
			transform.Translate(Vector3.right * (horizontalInput * Time.deltaTime * speed));

			// Keep the player form going too far left
			if (transform.position.x < -xRange)
			{
				var transform1 = transform;
				var position = transform1.position;
				position = new Vector3(-xRange, position.y, position.z);
				transform1.position = position;
			}

			// Keep the player form going too far right
			if (transform.position.x > xRange)
			{
				var transform1 = transform;
				var position = transform1.position;
				position = new Vector3(xRange, position.y, position.z);
				transform1.position = position;
			}
			
			// Fire food from the player
			if (Input.GetKeyDown(KeyCode.Space))
			{
				// Launch a projectile from the player
				Instantiate(foodPrefab, shotPrefabFrom.transform.position, foodPrefab.transform.rotation);
			}
		}
	}
}