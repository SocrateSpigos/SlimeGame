using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public GameObject icoSphere;
    public bool plusOne = false;

    void Update()
    {
        if (!icoSphere.scene.IsValid())
         {
            Debug.Log("plusONe");
            //collectSound.Play();
            ScoreSystem.slimeScore += 1;
            Destroy(gameObject, 2f);
        }
    }
}
