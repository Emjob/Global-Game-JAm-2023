using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    private bool paused = false;
    


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            Time.timeScale = 0f;
            Debug.Log("pausing game");
            PauseMenu.SetActive(true);
            paused = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            unpause();
        }
    }

    public void unpause()
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        Debug.Log("returning to game");
        paused = false;
    }
}
