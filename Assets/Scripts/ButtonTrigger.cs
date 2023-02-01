using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public bool pressed;

    public GameObject Button;
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ouch");
        pressed = true;
    }
}
