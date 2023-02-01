using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{

  
    

    public float cameraSize;
    public float cameraAspect;
    float width;

    public bool playerOne;
    public bool playerTwo;
    
    

    // Start is called before the first frame update
    void Start()
    {

        width = 2 * cameraSize * cameraAspect;


}

    // Update is called once per frame
    void Update()
    {
        if(playerOne && playerTwo)
        {
            transform.Translate(width, 0, 0);
            playerOne = false;
            playerTwo = false;
        }
    }

    void OnTriggerEnter2D(Collider2D otherObj)
    {
        if (otherObj.tag == "Player1")
        {
            playerOne = true;
            
           
        }
        if (otherObj.tag == "Player2")
        {
            playerTwo = true;
           

        }
    }
}
