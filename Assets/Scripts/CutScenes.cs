using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScenes : MonoBehaviour
{
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject Panel4;
    public GameObject Panel5;
    public GameObject Panel6;

    public Color MyColor;
    public Renderer MyRenderer;

    private float Alpha;
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
        Debug.Log(Alpha);
        while(Alpha<100)
        {
        Alpha = Alpha+ 5/3;
        }
        if(Alpha >= 100)
        {
        StartCoroutine(SceneCut());
        }
        while(Alpha>0)
        {
        Alpha = Alpha+ 5/3;
        }
        if(Alpha<=0)
        {
            StartCoroutine(SceneCut());
        }




        

    }
    IEnumerator SceneCut()
   {
        
        yield return new WaitForSeconds(2);


   }

}
