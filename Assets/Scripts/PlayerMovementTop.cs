using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTop : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float jumpPower = 5.0f;

    public Collider2D groundCheck;

    private Rigidbody2D _playerRigidbody;
    private bool isGrounded;
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

        if (Input.GetKeyDown("w") && isGrounded == true)
        {
            Jump();
        }
    }
    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        _playerRigidbody.velocity = new Vector2(horizontalInput * playerSpeed, _playerRigidbody.velocity.y);
    }
    private void Jump()
    {
        _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, jumpPower);
    }

    private void OnTriggerEnter2D(Collider2D groundCheck)
    {
        isGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D groundCheck)
    {
        isGrounded = false;
    }

}
