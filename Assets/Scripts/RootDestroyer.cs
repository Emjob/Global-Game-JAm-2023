using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootDestroyer : MonoBehaviour
{
    public GameObject bigRoot;
    public Collider2D colliding;
    public SpriteRenderer rending;

    public void Start()
    {
       //new float roots = bigRoot.GetComponent<rootsTree>().rootsGone;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "breaker")
        {
            //roots++;
            bigRoot.GetComponent<rootsTree>().rootsGone++;
            colliding.enabled = false;
            rending.enabled = false;
        }
    }
}
