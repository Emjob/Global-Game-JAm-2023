using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScenes : MonoBehaviour
{
    public GameObject Panel1;


    public Color MyColor;
    public Renderer MyRenderer;
    private bool Fadein = true;

    private float Alpha =0.1f;
    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine(SceneCut());
    }

    // Update is called once per frame
    void Update()
    {
        MyRenderer = Panel1.GetComponent<Renderer>();
        MyColor = new Color(1,1,1,Alpha/100);
        MyRenderer.material.color = MyColor;
        StartCoroutine(SceneCut());
        //Debug.Log(Alpha);
        if(Alpha >= 100)
        {
            Fadein = false;
            
        }
                if(Fadein)
        {
        Alpha = Alpha+ 5/3;
        
        }


    }
    IEnumerator SceneCut()
   {
        yield return new WaitForSeconds(2);
                if(Alpha<=0)
        {
            
        }
                if(!Fadein)
        {
        Alpha = Alpha- 5/3;
       
        }

        yield return new WaitForSeconds(2);
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
        Debug.Log("moving on");


   }

}
