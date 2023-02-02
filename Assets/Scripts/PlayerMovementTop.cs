using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTop : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float jumpPower = 5.0f;

    public Transform grasshopper;
    public GameObject grasshopperG;
    public Collider2D groundCheck;

    public bool jumping;
    public bool falling;

    private Rigidbody2D _playerRigidbody;
    public bool isGrounded;
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

        if (_playerRigidbody.velocity.y > 0.25)
        {
            jumping = true;
            falling = false;
            grasshopperG.GetComponent<Animator>().Play("GrassHopperJump");
        }
        if (_playerRigidbody.velocity.y < -0.25 && groundCheck == true)
        {
            jumping = false;
            falling = true;
            grasshopperG.GetComponent<Animator>().Play("GrassHopperFall");
        }
        if (_playerRigidbody.velocity.y > -0.1 && _playerRigidbody.velocity.y < 0.1)
        {
            jumping = false;
            falling = false;
        }
        if (jumping == false && falling == false)
        {
            if(_playerRigidbody.velocity.x > 0.1)
            {
                grasshopperG.GetComponent<Animator>().Play("GrassHopperRun");
                grasshopper.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if(_playerRigidbody.velocity.x < -0.1)
            {
                grasshopperG.GetComponent<Animator>().Play("GrassHopperRun");
                grasshopper.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
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

    private void OnTriggerStay2D(Collider2D groundCheck)
    {
        isGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D groundCheck)
    {
        isGrounded = false;
    }

}
