using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Enemy_Movement : MonoBehaviour
{
    public GameObject Player2;
    public GameObject Player1;

    public float distanceToPlayer2;
    public float distanceToPlayer1;

    private Transform targetPlayer;

    public float enemyTargetDistance;

    public float speed;

 //   public Transform playerDistance;

    // Start is called before the first frame update
    void Start()
    {
      //  playerDistance = GameObject.FindGameObjectWithTag("Player2").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer2 = Vector3.Distance(transform.position, Player2.transform.position);
        distanceToPlayer1 = Vector3.Distance(transform.position, Player1.transform.position);
        
        if (distanceToPlayer1 < enemyTargetDistance || distanceToPlayer2 < enemyTargetDistance)
        {
            if (distanceToPlayer2 < distanceToPlayer1)
            {
                followPlayer2();
            }
            if (distanceToPlayer1 < distanceToPlayer2)
            {
                followPlayer1();
            }
        }
    }

    void followPlayer2()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player2").GetComponent<Transform>();
        transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);

        var yVelocity = rigidbody2D.velocity.y;
        if(yVelocity < 0)
    }

    void followPlayer1()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player1").GetComponent<Transform>();
        transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
    }
}
