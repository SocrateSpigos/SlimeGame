using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedBay : MonoBehaviour
{
    //public PlayerHP playerHp;
    private PlayerHP playerHp;

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Character");
        playerHp = GameObject.Find("Player").GetComponent<PlayerHP>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Character")
        {
           if (ScoreSystem.goldScore > 0 && playerHp.currentHealth < 100)
            {
                InvokeRepeating("Healing", 0, 1f);

            }


            /*  while (ScoreSystem.goldScore > 0 && playerHp.currentHealth < 100)
          {
              ScoreSystem.goldScore -= 1;
              playerHp.Heal(1);


          }*/
        }

    }

    void OnTriggerExit(Collider other)
    {
        CancelInvoke("Healing");

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
