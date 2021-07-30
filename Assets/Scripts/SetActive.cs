using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    public GameObject nextTerrain;
    public GameObject mySelf;

   void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Vacuum")
        {
           /* nextTerrain.SetActive(true);
            mySelf.SetActive(false);*/
        }
    }

    public void NextMap()
    {
        nextTerrain.SetActive(true);
        mySelf.SetActive(false);
    }
}
