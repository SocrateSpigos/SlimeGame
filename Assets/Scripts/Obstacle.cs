using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) //basic stuff, just triggering animations and the interface. We have neither yet,
                                                //but should be trivial to plug them in, especially with the crossroads
    {
        if (other.CompareTag("Player"))
        {
            //todo initiate lose screen
            //todo initiate knockout animation (fall back and hoverboard flies off?/fall down a hole?)
            Crossroad.movementScript.movespeed = 0;
        }
    }
}
