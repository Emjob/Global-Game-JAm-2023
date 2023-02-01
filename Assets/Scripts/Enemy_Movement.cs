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

    private bool BYAlive;
    public Transform player;
    private Vector3 heading;
    private Vector3 pos;

    private float YBuffer;

    public bool UpDetect;
    public bool DownDetect;
    public bool LeftDetect;
    public bool RightDetect;

    public float SensorScore;


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

        Vector3 pos = player.transform.position;
        Vector3 heading = (player.transform.position - gameObject.transform.position).normalized;

          if (heading.y < YBuffer && BYAlive == false && DownDetect)
          {
           var breaker = Instantiate(breakerY, DownB.transform.position, DownB.transform.rotation);
            BYAlive = true;
            StartCoroutine(Wait(0.2f));
        //Debug.DrawLine(pos, pos - heading * 10, Color.red, Mathf.Infinity);
        }

        if (UpDetect && BYAlive == false && SensorScore >= 2)
        {
            
         var  breaker = Instantiate(breakerY, UpB.transform.position, UpB.transform.rotation);
           breaker.transform.parent = gameObject.transform;
            BYAlive = true;
            StartCoroutine(Wait(0.2f));
          
        }
        if (DownDetect && BYAlive == false && SensorScore >= 2)
        {

            var breaker = Instantiate(breakerY, DownB.transform.position, DownB.transform.rotation);
            breaker.transform.parent = gameObject.transform;
            BYAlive = true;
            StartCoroutine(Wait(0.2f));

        }
        if (LeftDetect && BYAlive == false && SensorScore >= 2)
        {

            var breaker = Instantiate(breakerY, LeftB.transform.position, LeftB.transform.rotation);
            breaker.transform.parent = gameObject.transform;
            BYAlive = true;
            StartCoroutine(Wait(0.2f));

        }
        if (RightDetect && BYAlive == false && SensorScore >= 2)
        {

            var breaker = Instantiate(breakerY, RightB.transform.position, RightB.transform.rotation);
            breaker.transform.parent = gameObject.transform;
            BYAlive = true;
            StartCoroutine(Wait(0.2f));

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
