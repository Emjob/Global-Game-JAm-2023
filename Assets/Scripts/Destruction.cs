using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    public GameObject PoofEffect;
    private GameObject Dead;
    private float PosX;
    private float PosY;
    // Start is called before the first frame update
    void Start()
    {
        Dead = this.gameObject;
        PosX = this.gameObject.transform.position.x;
        PosY = this.gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "breaker")
        {
            Destroy(this.gameObject);
            Instantiate(PoofEffect, new Vector2(PosX,PosY), Quaternion.identity);
           // Debug.Log("ouch");
        }
    }
}
