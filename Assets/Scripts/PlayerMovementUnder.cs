using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementUnder : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f;

    private Rigidbody2D _playerRigidbody;
    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        if (_playerRigidbody == null)
        {
            Debug.LogError("Player is missing a Rigidbody2D component");
        }
    }
    private void Update()
    {
        MovePlayer();

    }
    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxisRaw("Debug Horizontal");
        _playerRigidbody.velocity = new Vector2(horizontalInput * playerSpeed, _playerRigidbody.velocity.y);
        
        var verticalInput = Input.GetAxisRaw("Debug Vertical");
        _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, verticalInput * playerSpeed);

    }
}