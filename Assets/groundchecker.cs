using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundchecker : MonoBehaviour
{
    public bool grounded = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "tree")
        {
            grounded = true;
        }
    }
}
