using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rootsTree : MonoBehaviour
{
    public float rootsGone;
    public float speed;
    public float angle;
    public Transform tree;

    public void FixedUpdate()
    {
        angle = tree.rotation.eulerAngles.z;
        if(rootsGone >= 4)
        {
            //tree falls
            //Debug.Log("tree falls");
            Rotater();
        }
    }

    void Rotater()
    {
        if(angle >= 270f)
        {
            tree.transform.Rotate(0, 0, Time.deltaTime * speed);
        }
        else
        {
            tree.transform.Rotate(0, 0, 0);
        }
    }
}
