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

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Character")
        {
            while (ScoreSystem.goldScore > 0 && playerHp.currentHealth < 100)
            {
                
                ScoreSystem.goldScore -= 1;
                playerHp.Heal(1);
            }
        }

    }
    void Update()
    {
        
    }
}
