using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Width : MonoBehaviour
{

    public float width;
    // Start is called before the first frame update
    void Start()
    {
        
        width = GetComponent<Camera>().aspect;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
