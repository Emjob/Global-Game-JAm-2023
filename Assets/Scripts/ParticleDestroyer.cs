using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{
    void Update()
    {
        StartCoroutine(die());
    }
    IEnumerator die()
    {
       yield return new WaitForSeconds(1);
         Destroy(this.gameObject);

    }
}
