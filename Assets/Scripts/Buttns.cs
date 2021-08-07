using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Buttns : MonoBehaviour
{
    public Button btn;
    public int price;
    public BuildSelection builder;
    public GameObject canvas;
    public bool hub;

    void Start()
    {
        builder = canvas.GetComponent<BuildSelection>();

    }

    void Awake()
    {
        btn.interactable = false;
    }


    void Update()
    {
        hub = builder.cM;
        
        if (builder.cM && ScoreSystem.goldScore > price)
        {

                btn.interactable = true;      
        }

        else
        {
            btn.interactable = false;

        }
    }
}
