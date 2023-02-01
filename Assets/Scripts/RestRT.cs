using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestRT : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartOver()
    {
         int nextSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(nextSceneIndex);
        Time.timeScale = 1f;
    }

    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
