using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedBay : MonoBehaviour
{
    private PlayerHP playerHp;
    private GameObject healFX;

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Character");
        playerHp = GameObject.Find("Player").GetComponent<PlayerHP>();
        healFX = GameObject.Find("HealStream");
        ScoreSystem.goldScore -= 20;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Character")
        {
           if (ScoreSystem.goldScore > 0 && playerHp.currentHealth < 100)
            {

                InvokeRepeating("Healing", 0, 1f);
                healFX.SetActive(true);
            }

            else
            {
                CancelInvoke("Healing");
              //  healFX.SetActive(false);

            }


            /*  while (ScoreSystem.goldScore > 0 && playerHp.currentHealth < 100)
          {
              ScoreSystem.goldScore -= 1;
              playerHp.Heal(1);


          }*/
        }

    }
 



    void Healing()
    {
        ScoreSystem.goldScore -= 1;
        playerHp.Heal(5);
    }
    void Update()
    {
        
    }
}
