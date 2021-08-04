using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Buttns : MonoBehaviour
{
    private Button btn;
    public GameObject hub;
    public int price;
    public BuildSelection build;
    public GameObject canvas;

    void Awake()
    {
        btn.interactable = false;
        build = canvas.GetComponent<BuildSelection>();
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
