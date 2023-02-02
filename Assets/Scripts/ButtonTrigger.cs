using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public bool pressed;

    public GameObject Button;
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(ThingThatMoves==null)
        {
            return;
        }
        else
        {
            pressed = true;
            ThingThatMoves.StartCoroutine(lerpies());
            ThingThatMoves.groovin = true;
            Debug.Log("ouch");
        }


    }

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
   public bool returning;
   public ButtonTrigger ThingThatMoves;

   void Start()
    {
        starties = ThingThatMoves.transform.position;
    }

    
    void Update()
    {
        //ThingThatMoves.transform.Translate(sped * Time.deltaTime);
        //ThingThatMoves.transform.Rotate(rotato * Time.deltaTime);
        //ThingThatMoves.transform.localScale += bigness;
    }


    IEnumerator lerpies()
    {
        if(pressed)
        {
        timepassed = 0;
        while (timepassed<timetaken)
        {

            timepassed += Time.deltaTime;
            float percentcomplete = Mathf.Clamp(timepassed / timetaken,0,1);
            ThingThatMoves.transform.position = Vector3.Lerp(starties,endies,curve.Evaluate(percentcomplete));
            yield return null;
        }

        if(returning)
        {
            timepassed = 0;
            while (timepassed<timereturned)
            {
            
                timepassed += Time.deltaTime;
                float percentundone = Mathf.Clamp(timepassed / timereturned,0,1);
                ThingThatMoves.transform.position = Vector3.Lerp(endies,starties,reverseCurve.Evaluate(percentundone));
                yield return null;
            }
            groovin = false;
        }
        }
    }    
}
