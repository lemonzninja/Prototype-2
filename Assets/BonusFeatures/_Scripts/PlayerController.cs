using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // The projectile prefab
	[SerializeField] private GameObject projectilePrefab;
	
	// player movement variables
	public float horizontalInput;
	public float verticalInput;
	
	[SerializeField] private float speed = 10.0f;

    // The left and right boundaries for the player
	[SerializeField] private float xPosMin = 0.0f;
	[SerializeField] private float xPosMax = 0.0f;
	// The top and bottom boundaries for the player    
	[SerializeField] private float zPosMin = 0.0f;
	[SerializeField] private float zPosMax = 0.0f;

	private void Update()
	{
		MovePlayer();
		KeepPlayerInBounds();
	}
	
	private void MovePlayer()
	{
		// Move the player left and right
		horizontalInput = Input.GetAxis("Horizontal");
		transform.Translate(Vector3.right * (horizontalInput * Time.deltaTime * speed));
		
		// Move the player forward and backward
		verticalInput = Input.GetAxis("Vertical");
		transform.Translate(Vector3.forward * (verticalInput * Time.deltaTime * speed));
	}

	private void KeepPlayerInBounds()
	{
		/*
		 * Keep the player in bounds
		 */
		
		// Keep the player form going off the bottom of the screen
		if (transform.position.x < xPosMin)
		{
			var transform1 = transform;
			var position = transform1.position;
			
			position = new Vector3(xPosMin, position.y, position.z);
			transform1.position = position;
		}
		// Keep the player form going off the top of the screen
		if (transform.position.x > xPosMax)
		{
			var transform1 = transform;
			var position = transform1.position;
			
			position = new Vector3(xPosMax, position.y, position.z);
			transform1.position = position;
		}
        // Keep the player form going off the left of the screen
		if (transform.position.y < zPosMin)
		{
			var transform1 = transform;
			var position = transform1.position;
			
			position = new Vector3(position.x, position.y, zPosMin);
			transform1.position = position;
		}
		// Keep the player form going off the right of the screen
		if (transform.position.y > zPosMax)
		{
			var transform1 = transform;
			var position = transform1.position;
			
			position = new Vector3(position.x, position.y, zPosMax);
			transform1.position = position;
		}
	}
}