using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonPressGrasshopper : MonoBehaviour
{
    public GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
        
    }


        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                platform.GetComponent<Transforms>().enabled = true;
            }
        }
    
}
