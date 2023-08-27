using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
	// Destroy both objects when they collide.
	
	private void OnTriggerEnter(Collider other)
	{
		Destroy(gameObject);
		Destroy(other.gameObject);
	}	
}