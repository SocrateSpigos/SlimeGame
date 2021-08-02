using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{

    public Button btn;
    public int price;

    void Awake()
    {
        btn.interactable = false;

    }


    void Update()
    {
        if (ScoreSystem.goldScore > price)
        {

            btn.interactable = true;
          
        }

        else
        {
            btn.interactable = false;

        }
    }

}
