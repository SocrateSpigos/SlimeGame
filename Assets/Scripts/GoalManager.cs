using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;

public class GoalManager : MonoBehaviour
{
    public int[] goal; //index as per block color
    public int difficulty;
    public int[] matchTotal = { 0, 0, 0};
    public void Start()//LoadGoal() this can be changed (or added!) if we go with premade tasks
    {
        for (int i = 0; i < difficulty; i++)
        {
            goal[Random.Range(0, 3)] += 3;              //randomly add, essentially, a single basic match per difficulty level
        }
    }
    public void ReportMatch(BlockColor color)           //when a block gets matched, it'll ring here
    {
        goal[(int) color]--;                            //goals updated
        matchTotal[(int) color]++;                      //count this newest success
        if (goal[(int) color] < 0) goal[(int) color] = 0;//don't update goal too far
        if (Array.TrueForAll(goal, IsZero))             //dark magic to see if all goals are completed
        {
            Crossroad.groundGen.ReportFinish();         //get that finish spawning
        }
    }

    public void ResolveScore()                          //where the score magic happens, called once the entirety of a chain reaction is resolved
    {
        int newFuel = 0;
        int variety = 0;
        Crossroad.score += matchTotal[0] + matchTotal[1] + matchTotal[2];   //score is straightforward, 1 per block matched. Combos are valued elsewhere
        for (int i = 0; i < 3; i++)                                         //for each color
        {
            if (matchTotal[i] > 2)                                          //if we have at least a basic match
            {
                newFuel += variety;                                         //get an increasing fuel bonus for multiple colors matched
                variety++;
                newFuel += matchTotal[i] - 2;                               //and increasing payoff for bigger matches, with a minimum of 1
            }
            matchTotal[i] = 0;                                              //won't be needing this now
            
        }

        Crossroad.fuel += newFuel;                                          //add result to fuel, which means multipliers
        if (Crossroad.fuel > Crossroad.mxFl) Crossroad.fuel = 32;
    }
    private bool IsZero(int i)              //ok, it wasn't dark magic, just a touch more convenient to write that way
    {
        return i == 0;
    }
}
