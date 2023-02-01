using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class Enemy_Movement : MonoBehaviour
{
    public GameObject Player2;
    public GameObject Player1;

    public float distanceToPlayer2;
    public float distanceToPlayer1;

    private Transform targetPlayer;

    public float enemyTargetDistance;

    public float speed;

    public GameObject breakerY;
    public GameObject breakerX;

    public Transform LeftB;
    public Transform RightB;
    public Transform UpB;
    public Transform DownB;

    public float yVelocity;
    public float xVelocity;

    public bool BYAlive;
    public Transform player;
    public Vector3 heading;
    public Vector3 pos;

    public float YBuffer;
    

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

        yVelocity = GetComponent<Rigidbody2D>().velocity.y;
        xVelocity = GetComponent<Rigidbody2D>().velocity.x;

        
        
        



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

        //  yVelocity = GetComponent<Rigidbody2D>().velocity.y;

        Vector3 pos = player.transform.position;
        Vector3 heading = (player.transform.position - gameObject.transform.position).normalized;

          if (heading.y < YBuffer && BYAlive == false)
          {
           var breaker = Instantiate(breakerY, DownB.position, DownB.rotation);
            BYAlive = true;
            StartCoroutine(Wait(0.7f));
        //Debug.DrawLine(pos, pos - heading * 10, Color.red, Mathf.Infinity);
        }

        if (yVelocity < 0 && BYAlive == false)
        {
            
        // var  breaker = Instantiate(breakerY, UpB.position, UpB.rotation);
         //  breaker.transform.parent = gameObject.transform;
         //   BYAlive = true;
            StartCoroutine(Wait(0.7f));
          
        }
    }
    private IEnumerator Wait(float delay)
    {
        yield return new WaitForSeconds(delay);
        BYAlive = false;
    }

    void followPlayer1()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player1").GetComponent<Transform>();
        transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
    }


}
