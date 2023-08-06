using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 10.0f;
    [SerializeField] private float horizontalScreenBoundaryPos;
    [SerializeField] private float verticalScreenBoundaryPos;
    
    private float horizontalInput;
    private float verticalInput;
    
    private Vector3 _playerPos;
    private Vector3 _position;
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
        _position = transform.position;
    }

    private void Update()
    {
        MovePlayer();
        KeepPlayerOnScreen();
    }

    private void MovePlayer()
    {
        // Get left/right input.
        horizontalInput = Input.GetAxis("Horizontal");
        _position += Vector3.right * (horizontalInput * moveSpeed * Time.deltaTime);
        
        // Get up/down input.
        verticalInput = Input.GetAxis("Vertical");
        _position += Vector3.forward * (verticalInput * moveSpeed * Time.deltaTime);
        
        _transform.position = _position;
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