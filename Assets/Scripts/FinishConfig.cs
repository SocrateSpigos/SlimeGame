using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishConfig : MonoBehaviour
{
    public GameObject hoverground;
    public GameObject multiplier;
    public GameObject scoreZones;

    private int extension = 1;

    /*private void Update()
    {
        if (extension < (int) Crossroad.fuel/ 5 + 20)
        {
            StartCoroutine(SpawnMultiplier(extension));
            extension++;
        }
    }*/

    public void Trigger()
    {
      
        float fuel = Crossroad.fuel*Crossroad.FuelMult;
        hoverground.transform.localScale = new Vector3(3, 1, fuel);
        hoverground.transform.Translate(new Vector3(0, 0, fuel / 2));
    }

    /*void Start()
    {
        float fuel = Crossroad.fuel;
        //adjust this number as desired - should be fine though
        int scorelength = (int) fuel / 5 + 20;      //enough to cover our stretch and the horizon after it.
        hoverground.transform.localScale = new Vector3(3, 1, fuel);     //spread invisible floor so we 'fly'
        hoverground.transform.Translate(new Vector3(0, 0, fuel/2)); //but spread it in the right direction

        for (int i = 1; i < scorelength; i++) //again, adjust fuel as necessary
        {
            StartCoroutine(SpawnMultiplier(i));
        }
    }*/

    IEnumerator SpawnMultiplier(int index) //spawn each piece of the finish line zones
    {
      
        GameObject mp = Instantiate(multiplier, scoreZones.transform);
        mp.transform.localPosition = new Vector3(0, 0, index);
        mp.GetComponent<MultipliersTargets>().Config(index);
        yield return null;
    }
}
