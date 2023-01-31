using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transforms : MonoBehaviour
{
   public Vector3 rotato;
   public Vector3 bigness;
   public Vector2 sped;
   private Vector2 starties;
   public Vector2 endies = new Vector2(0,0);
   public float timetaken;
   public float timereturned;
   private float timepassed;
   [SerializeField] private AnimationCurve curve;
   [SerializeField] private AnimationCurve reverseCurve;
   private bool groovin;
   

    void Start()
    {
        starties = transform.position;
    }

    
    void Update()
    {
        transform.Translate(sped * Time.deltaTime);
        transform.Rotate(rotato * Time.deltaTime);
        transform.localScale += bigness;

        if(!groovin)
        {
            StartCoroutine(lerpies());
            groovin = true;
        }    
    }


    IEnumerator lerpies()
    {
        timepassed = 0;
        while (timepassed<timetaken)
        {
            
            timepassed += Time.deltaTime;
            float percentcomplete = Mathf.Clamp(timepassed / timetaken,0,1);
            transform.position = Vector3.Lerp(starties,endies,curve.Evaluate(percentcomplete));
            yield return null;
        }
        timepassed = 0;
        while (timepassed<timetaken)
        {
            
            timepassed += Time.deltaTime;
            float percentundone = Mathf.Clamp(timepassed / timetaken,0,1);
            transform.position = Vector3.Lerp(endies,starties,reverseCurve.Evaluate(percentundone));
            yield return null;
        }
        groovin = false;
    }

}
