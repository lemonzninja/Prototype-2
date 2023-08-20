using UnityEngine;

namespace _Scripts
{
	public class DestroyOutOfBounds : MonoBehaviour
	{
		private const float _topBound = 30.0f;
		private const float _lowerBound = -10.0f;

		private const float _sideBound = 30.0f;
		
		private void Update()
		{
			if (transform.position.z > _topBound || 
			    transform.position.z < _lowerBound ||
			    transform.position.x > _sideBound ||
			    transform.position.x < -_sideBound)
			{
				Destroy(gameObject);
			}
		}
	}
}