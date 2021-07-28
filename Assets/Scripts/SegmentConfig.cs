using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class SegmentConfig : MonoBehaviour
{
    public BlockColor[] colors = new BlockColor[] {BlockColor.Blue, BlockColor.Green, BlockColor.Red};
    public GameObject[] placeholderRed;                     //these categories split the objects in 'same colors in the pattern'
    public GameObject[] placeholderBlue;
    public GameObject[] placeholderGreen;
    public GameObject[][] pieces =new GameObject[3][];      //this will come to hold the above categories

    private void Start()
    {
        pieces = new GameObject[3][] {placeholderRed, placeholderBlue, placeholderGreen};
        Randomizer.Randomize(colors);
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < pieces[i].Length; j++)
            {
                if (pieces[i][j].GetComponent<PickupCollision>() != null)               //set up the two types of colored things:
                {
                    pieces[i][j].GetComponent<PickupCollision>().Config(colors[i]);     //blocks
                }
                else
                {
                    pieces[i][j].GetComponent<ZoneCollision>().Config(colors[i]);      //and zones
                }
            }
        }
         
    }
}

public class Randomizer                                 //assign each group in the category a unique color
{
    public static void Randomize<T>(T[] items)
    {
        

        // For each spot in the array, pick
        // a random item to swap into that spot.
        for (int i = 0; i < items.Length - 1; i++)
        {
            int j = Random.Range(i, items.Length - 1);
            T temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }
    }
}