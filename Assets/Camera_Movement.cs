using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{

  
    

    public float cameraSize;
    public float cameraAspect;
     public float width;
    
    

    // Start is called before the first frame update
    void Start()
    {

        width = 2 * cameraSize * cameraAspect;


}

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D otherObj)
    {
        if (otherObj.tag == "Player")
        {
            
            transform.Translate(width, 0, 0);
           
        }
    }
}
