using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonPress : MonoBehaviour
{
    public GameObject platform;
    //ScriptName script;
    // Start is called before the first frame update
    void Start()
    {
        //script = platform.GetComponent<Transforms> ();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "breaker")
        {
            platform.GetComponent<Transforms>().enabled = true;
        }
    }
}
