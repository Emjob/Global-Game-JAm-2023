using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transforms : MonoBehaviour
{
   public Vector3 rotato;
   public Vector3 bigness;
   private Vector3 starties;
   public Vector3 endies = new Vector3(0,0,0);
   public float timetaken;
   private float timepassed;
   [SerializeField] private AnimationCurve curve;
   

    void start()
    {
        starties = transform.position;
    }

    
    void Update()
    {
        transform.Rotate(rotato * Time.deltaTime);
        transform.localScale += bigness;
        timepassed += Time.deltaTime;
        float percentcomplete = timepassed / timetaken;
        transform.position = Vector3.Lerp(starties,endies,curve.Evaluate(percentcomplete));
       // StartCoroutine(lerpies());
    }


   /* IEnumerator lerpies()
    {
        timepassed += Time.deltaTime;
        float percentcomplete = timepassed / timetaken;
        transform.position = Vector3.Lerp(starties,endies,pcurve.Evaluate(percentcomplete));
        yield return;
        yield return new WaitForSeconds(timetaken);
        transform.position = Vector3.Lerp(endies,starties,pcurve.Evaluate(percentcomplete));
        yield return;
    }*/

}
