using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refinery : MonoBehaviour
{
    
    

    void Start()
    {
        InvokeRepeating("SteadyIncome", 0f, 1f);
        ScoreSystem.goldScore -= 10;

    }

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

   

    void SteadyIncome()
    {
        ScoreSystem.slimeScore += 1;

    }
}
