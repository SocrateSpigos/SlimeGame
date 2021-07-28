using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public GameObject slimeText;
    public static int slimeScore;
    
    public GameObject goldText;
    public static int goldScore;

    int nextGold = 5;



    void Update()
    {
        slimeText.GetComponent<Text>().text = slimeScore.ToString();
        goldText.GetComponent<Text>().text = goldScore.ToString();


        if (slimeScore >= nextGold)
        {
            goldScore += 1;
            nextGold += 5;
        }


    }

}
