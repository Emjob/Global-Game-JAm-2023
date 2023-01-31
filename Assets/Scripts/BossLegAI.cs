using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLegAI : MonoBehaviour
{
    public GameObject LeftField;
    public GameObject RightField;
    public Vector2 speed;
    public float PlayerPos;
    private float BossPos;

    void Update()
    {

    }
  


     void OnTriggerStay2D (Collider2D other)
     {
        PlayerPos = other.gameObject.transform.position.x;
        BossPos = this.gameObject.transform.position.x;

    if(PlayerPos>BossPos)
    {
        transform.Translate(speed * Time.deltaTime);  
    }
    else
    {
        transform.Translate((speed * Time.deltaTime)*-1);
    }
     }
 
}
