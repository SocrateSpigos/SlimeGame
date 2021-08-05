using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refinery : MonoBehaviour
{
    
    

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Character")
        {
            while (ScoreSystem.slimeScore > 30)
            {

                ScoreSystem.slimeScore -= 3;
                ScoreSystem.goldScore += 1;
            }

        }

    }

   

    void Update()
    {
        
    }
}
