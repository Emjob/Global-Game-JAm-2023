using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject endScene;
    public int PlayerCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerCount ++;
            if(PlayerCount == 3)
            {
                endScene.SetActive(true);
                StartCoroutine(WaitToLeave());

            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
        {
        if(other.tag == "Player")
        {
            PlayerCount --;
        }
        }
        IEnumerator WaitToLeave()
        {
            yield return new WaitForSeconds(1);
                        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);

        }
}
