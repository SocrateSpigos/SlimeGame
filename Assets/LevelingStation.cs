using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelingStation : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Character")
        {
            //Time.timeScale = 0;
        }
    }
}
