using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSelection : MonoBehaviour
{
    public GameObject slimeFactory;
    public GameObject commandCenter;
    public GameObject market;
    public GameObject levelingStation;
    public GameObject medBay;
    public GameObject turrets;

    

    public void spawnSlimeFactory()
    {
        Instantiate(slimeFactory);
    }

    public void spawnCommandCenter()
    {
        if (ScoreSystem.goldScore >= 50)
        {
            Instantiate(commandCenter);
            ScoreSystem.goldScore -= 50;

        }
    }

    public void spawnMarket()
    {
        Instantiate(market);
    }

    public void spawnLevelingStation()
    {
        Instantiate(levelingStation);
    }

    public void spawnMedbay()
    {
        Instantiate(medBay);
    }

    public void spawnTurrets()
    {
        Instantiate(turrets);
    }
}
