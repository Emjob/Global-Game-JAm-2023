using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneProgress : MonoBehaviour
{

    

    public void startgame()
    {
         int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void quitgame()
    {
        Application.Quit();
        Debug.Log("quitting game");
    }
}
