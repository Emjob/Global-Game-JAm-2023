using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLegAI : MonoBehaviour
{
    public GameObject LeftField;
    public GameObject RightField;
    public Vector2 speed;
    public float PlayerPos;
    private float BossPos;
    private bool slamming;
    private Vector2 starties;
   public Vector2 endies = new Vector2(0,0);
   public float timetaken;
   public float timereturned;
   private float timepassed;
   [SerializeField] private AnimationCurve curve;
   [SerializeField] private AnimationCurve reverseCurve;
   bool waiting = true;
  
    IEnumerator Wait()
    {
        waiting = false;
        yield return new WaitForSeconds(6);
        waiting = true;
        
    }
    
     void OnTriggerStay2D (Collider2D other)
     {
        PlayerPos = other.gameObject.transform.position.x;
        BossPos = this.gameObject.transform.position.x;
    if(!slamming)
    {
        if(waiting)
        {
            StartCoroutine(Wait());
            StartCoroutine (Slam());
            slamming = true;
            endies.x = BossPos;
            starties.x = BossPos;
            starties.y = 8;
            endies.y = 5;
        }
        if(PlayerPos>BossPos)
        {
            transform.Translate(speed * Time.deltaTime);  
        }
        else
        {
            transform.Translate((speed * Time.deltaTime)*-1);
        }

    }
     

     IEnumerator Slam()
     {
        
       yield return new WaitForSeconds(1);
        LeftField.SetActive(false);
        RightField.SetActive(false);

        timepassed = 0;
        while (timepassed<timetaken)
        {
            
            timepassed += Time.deltaTime;
            float percentcomplete = Mathf.Clamp(timepassed / timetaken,0,1);
            transform.position = Vector3.Lerp(starties,endies,curve.Evaluate(percentcomplete));
            yield return null;
        }
        yield return new WaitForSeconds(1);
        timepassed = 0;
        while (timepassed<timereturned)
        {
            
            timepassed += Time.deltaTime;
            float percentundone = Mathf.Clamp(timepassed / timereturned,0,1);
            transform.position = Vector3.Lerp(endies,starties,reverseCurve.Evaluate(percentundone));
            yield return null;
        }


        yield return new WaitForSeconds(1);
        slamming = false;
        LeftField.SetActive(true);
        RightField.SetActive(true);

     }
 
}
}
