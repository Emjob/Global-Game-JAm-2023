using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionUp : MonoBehaviour
{
    public Enemy_Movement Detect;
    public Enemy_Movement Score;

    void start()
    {
        GameObject DS = GameObject.FindGameObjectWithTag("Sensor");
        Detect = DS.GetComponent<Enemy_Movement>();
        Score = DS.GetComponent<Enemy_Movement>();
    }

    void OnTriggerEnter2D(Collider2D otherObj)
    {
        if (otherObj.tag == "Dig")
        {
            Detect.UpDetect = true;
            Score.SensorScore += .25f;
        }
    }

    void OnTriggerExit2D(Collider2D otherObj)
    {
        if (otherObj.tag == "Dig")
        {
            Detect.UpDetect = false;
            Score.SensorScore -= .25f;
        }
    }
}
