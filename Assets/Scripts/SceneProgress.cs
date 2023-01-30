using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneProgress : MonoBehaviour
{

     int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

    void startgame()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
}
