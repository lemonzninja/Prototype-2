using UnityEngine;

namespace BonusFeatures._Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] public float moveSpeed = 10.0f;
        [SerializeField] private float horizontalScreenBoundaryPos;
        [SerializeField] private float verticalScreenBoundaryPos;
    
        private float _horizontalInput;
        private float _verticalInput;
    
        private Vector3 _playerPos;
        private Vector3 _position;
        private Transform _transform;

        // GameObject To fire the projectile from.
        [SerializeField] private GameObject firePoint;
        // The projectile prefab.
        [SerializeField] private GameObject projectilePrefab;
        
        // Add a small delay between firing projectiles.
        [SerializeField] private float delayTime = 0.5f;
        [SerializeField] private float fireDelay;
        
        
        private void Start()
        {
            var transform1 = transform;
            _transform = transform1;
            _position = transform1.position;
        }

        private void Update()
        {
            MovePlayer();
            KeepPlayerOnScreen();
            FireProjectile();
        }

        private void MovePlayer()
        {
            // Get left/right input.
            _horizontalInput = Input.GetAxis("Horizontal");
            _position += Vector3.right * (_horizontalInput * moveSpeed * Time.deltaTime);
        
            // Get up/down input.
            _verticalInput = Input.GetAxis("Vertical");
            _position += Vector3.forward * (_verticalInput * moveSpeed * Time.deltaTime);
        
            _transform.position = _position;
        }
        
        private void FireProjectile()
        {
            /*
             * Fire a projectile from the firePoint.
             */
            
            // Add a small delay between firing projectiles.
            if (fireDelay <= 0)
            {
                // Check if the space bar is pressed down.
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    fireDelay = delayTime;
                    
                    // Fire a projectile from the firePoint.
                    Instantiate(projectilePrefab, firePoint.transform.position, firePoint.transform.rotation);
                }
            }
            else
            {
                // Reduce the fireDelay by deltaTime.
                fireDelay -= Time.deltaTime;
            }
        }
    
        private void KeepPlayerOnScreen()
        {
            /*
             * keep player object on screen.
             */
        
            // Get player position.
            _playerPos = _position;
        
            // Clamp the player position to the screen boundaries.
            var xPos = Mathf.Clamp(_playerPos.x, -horizontalScreenBoundaryPos, horizontalScreenBoundaryPos);
            // Set the player position.
            _playerPos = new Vector3(xPos, _position.y, _position.z);
            _position = _playerPos;
        
            // Clamp the player position to the vertical screen boundaries.
            var zPos = Mathf.Clamp(_playerPos.z, -verticalScreenBoundaryPos, verticalScreenBoundaryPos);
            // Set the player position.
            _playerPos = new Vector3(_position.x, _position.y, zPos);
            _position = _playerPos;
        
        }
    }
}