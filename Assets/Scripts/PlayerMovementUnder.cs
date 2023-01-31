using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementUnder : MonoBehaviour
{

    [SerializeField] private float playerSpeed = 5.0f;

    public Transform badger;
    public GameObject badgerG;
    public float maxVelocity = 5;
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
        _playerRigidbody.velocity = Vector2.ClampMagnitude(_playerRigidbody.velocity, maxVelocity);

        if(_playerRigidbody.velocity.magnitude > 0.1 || _playerRigidbody.velocity.magnitude < -0.1)
        {
            badgerG.GetComponent<Animator>().Play("Badger_Run");
        } 
        if(_playerRigidbody.velocity.magnitude < 0.1 && _playerRigidbody.velocity.magnitude > -0.1)
        {
            badgerG.GetComponent<Animator>().Play("Badger_Idle");
        }
        if(_playerRigidbody.velocity.x < -0.1)
        {
            badger.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if(_playerRigidbody.velocity.x > 0.1)
        {
            badger.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxisRaw("Debug Horizontal");
        _playerRigidbody.velocity = new Vector2(horizontalInput * playerSpeed, _playerRigidbody.velocity.y);
        
        var verticalInput = Input.GetAxisRaw("Debug Vertical");
        _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, verticalInput * playerSpeed);

    }
}