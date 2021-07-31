using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyMap : MonoBehaviour
{
    public GameObject ant;
    public TextMesh text;
    private ScoreSystem score;
    public int price = 30;

    public GameObject nextTerrain;
    public GameObject mySelf;
    public GameObject theOther;

    void Awake()
    {
        text = gameObject.GetComponentInChildren<TextMesh>();
        score = ant.GetComponent<ScoreSystem>();
    }     
     
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Vacuum" || other.tag == "Trigger" && score.slime>0)
        {
            InvokeRepeating("Spend",0f, 3f);
        }

    }

    void Spend()
    {
        if (price > 0)
        {
            score.slime -= 1;
            price -= 1;
            ScoreSystem.slimeScore -= 1;

            text.text = price.ToString();
        }
        else
        {

            nextTerrain.SetActive(true);
            mySelf.SetActive(false);
            theOther.SetActive(false);
        }
    }



    void Update()
     {
        // text.text = "test";
     }
 }