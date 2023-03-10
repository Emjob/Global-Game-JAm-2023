using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class Enemy_Movement : MonoBehaviour
{
    public GameObject Player2;
    public GameObject Player1;

    private float distanceToPlayer2;
    private float distanceToPlayer1;

    private Transform targetPlayer;
    public Collider2D enemyCollider;

    public float enemyTargetDistance;

    public float speed;

    public GameObject breakerY;
    public GameObject breakerX;

    public GameObject LeftB;
    public GameObject RightB;
    public GameObject UpB;
    public GameObject DownB;
    

    private float yVelocity;
    private float xVelocity;

    public bool BYAlive;
    public Transform player;
    private Vector3 heading;
    private Vector3 pos;

    public float YBuffer;
    public float surface;

    public bool UpDetect;
    public bool DownDetect;
    public bool LeftDetect;
    public bool RightDetect;

    public float SensorScore;

    public bool goDown;


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
        if(gameObject.transform.position.y > surface)
        {
            GetComponent<Rigidbody2D>().gravityScale = 1f;
        } else if(gameObject.transform.position.y < surface)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        }
        
    }

   

    void followPlayer2()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("breaker").GetComponent<Transform>();
        transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);

        Vector3 pos = player.transform.position;
        Vector3 heading = (player.transform.position - gameObject.transform.position).normalized;


        //Debug.DrawLine(pos, pos - heading * 10, Color.red, Mathf.Infinity);
      goDown = true;
 

        if (UpDetect && BYAlive == false)
        {
            
         var  breaker = Instantiate(breakerY, UpB.transform.position, UpB.transform.rotation);
           breaker.transform.parent = gameObject.transform;
          //  BYAlive = true;
          //  StartCoroutine(Wait(0.2f));
          
        }
        if (DownDetect && BYAlive == false  )
        {

            var breaker = Instantiate(breakerY, DownB.transform.position, DownB.transform.rotation);
            breaker.transform.parent = gameObject.transform;
          //  BYAlive = true;
          //  StartCoroutine(Wait(0.2f));

        }
        if (LeftDetect && BYAlive == false )
        {

            var breaker = Instantiate(breakerX, LeftB.transform.position, LeftB.transform.rotation);
            breaker.transform.parent = gameObject.transform;
          //  BYAlive = true;
           // StartCoroutine(Wait(0.2f));

        }
        if (RightDetect && BYAlive == false )
        {

            var breaker = Instantiate(breakerX, RightB.transform.position, RightB.transform.rotation);
            breaker.transform.parent = gameObject.transform;
           // BYAlive = true;
          //  StartCoroutine(Wait(0.2f));

        }
    }
    private IEnumerator Wait(float delay)
    {
        yield return new WaitForSeconds(delay);
        BYAlive = false;
    }

    void followPlayer1()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);

        Vector3 pos = player.transform.position;
        Vector3 heading = (player.transform.position - gameObject.transform.position).normalized;

        goDown = false;

        if (UpDetect && BYAlive == false && heading.y > YBuffer)
        {

            var breaker = Instantiate(breakerY, UpB.transform.position, UpB.transform.rotation);
            breaker.transform.parent = gameObject.transform;
            BYAlive = true;
            StartCoroutine(Wait(0.2f));

        }
        if (LeftDetect && BYAlive == false)
        {

            var breaker = Instantiate(breakerX, LeftB.transform.position, LeftB.transform.rotation);
            breaker.transform.parent = gameObject.transform;
            BYAlive = true;
            StartCoroutine(Wait(0.2f));

        }
        if (RightDetect && BYAlive == false)
        {

            var breaker = Instantiate(breakerX, RightB.transform.position, RightB.transform.rotation);
            breaker.transform.parent = gameObject.transform;
            BYAlive = true;
            StartCoroutine(Wait(0.2f));

        }
    }

    
    
}
