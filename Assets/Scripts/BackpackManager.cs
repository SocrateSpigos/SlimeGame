using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class BackpackManager : MonoBehaviour            //the beating heart of the game's logic
{
    public float heightConstant;                        //we adjust this to change the height of backpack blocks, both visible and animation-wise
    public List<GameObject> blockStack;                 //where we keep an eye on our backpack

    public void AddBlock(GameObject block) //adds block to the top
    {
        int index = blockStack.Count;
        blockStack.Add(block);
        block.transform.DOLocalMove(new Vector3(0,index * heightConstant,0), 0); //index helps us tween the block to the right height
        //FindMatches();
        GetMatched();   //but it might be on the way out
    }

    public void RemoveColor(BlockColor color) //remove all of specified color
    {
        foreach (GameObject block in SearchColor(color)) //only the keyed color is returned here
        {
            block.GetComponent<BackpackBlock>().GotRemoved(); //just tell them all to go die
        }

        StartCoroutine(CleanAndMatch());
    }

    public IEnumerator CleanAndMatch()                  
    {
        yield return new WaitForEndOfFrame();           //don't rush and mess up
        CleanListUp();                                  //remove nulls before they break everything
        //FindMatches();
        GetMatched();                                   //find all matches
        DropBlocks();                                   //and animate their aftermath
    }

    public void CleanListUp() //garbage collect the list
    {
        blockStack.RemoveAll(item => item == null); //more dark magic
    }

    public List<GameObject> SearchColor(BlockColor color) //returns list of indexes with that color, for culling reasons
    {
        List<GameObject> matches = new List<GameObject>(); 
        
        foreach (GameObject block in blockStack)
        {
            if (block.GetComponent<BackpackBlock>().color == color) matches.Add(block);
        }

        return matches;
    }

    public void RemoveBlockByIndex(int index) //removes block at index - CAUTION, will cause trouble if used en masse. Luckily, apparently not to be used at all
    {
        blockStack[index].GetComponent<BackpackBlock>().GotRemoved();
        blockStack.RemoveAt(index);
        StartCoroutine(CleanAndMatch());
    }

    public void DropBlocks() //constructs a dotween sequence to move all the block gameobjects down, then runs it, then restarts the update loop
    {
        Sequence fall = DOTween.Sequence().SetEase(Ease.InQuad); //gravity-like quad
        for (int i = 0; i < blockStack.Count; i++)
        {
            fall.Insert(0f, blockStack[i].transform.DOLocalMoveY(i * heightConstant, 0.5f)); //get each block to fall where it must
        }

        fall.OnComplete(GetMatched); //should check for matches once the falling finishes
        fall.Play(); //now do it all
    }
//a monument to my failure, here in the off chance we need something
    /*public void FindMatches() //In charge of applying GetMatched to everything, skips same-colors    
    {
        bool matches = false;
        BlockColor lastColor = BlockColor.Nil;
        for (int i = 0; i < blockStack.Count; i++)
        {
            //if (blockStack[i].GetComponent<BackpackBlock>().color == lastColor) continue;
            //lastColor = blockStack[i].GetComponent<BackpackBlock>().color;
            matches = (matches || GetMatched(i, false));
            if (matches) break;
        }
        
        if (matches) StartCoroutine(CleanAndMatch());
    }*/

    /*public bool GetMatched(int index, bool matched) //recursively check if a match happens. If it does, propagate that downwards before returning, and trigger visuals
    {
        if (blockStack.Count < 3) return false; //can't match 3 without 3!
        bool match = false;
        if (index == 0) //first one can't be matched, move on to the next
        {
            match = GetMatched(1, false);
        }
        else if (index == blockStack.Count - 1) //last one can only get matched if the matching has already happened
        {
            match = (matched &&                 //specifically, if the previous one was matched
                     blockStack[index].GetComponent<BackpackBlock>().color      //and this one has the same color
                     == blockStack[index-1].GetComponent<BackpackBlock>().color);
            if (match) blockStack[index].GetComponent<BackpackBlock>().GotMatched(); //then it is matched
        }
        else //if we're at the midpoint, we're checking for matches!
        {
            BackpackBlock previous = blockStack[index - 1].GetComponent<BackpackBlock>();
            BackpackBlock next = blockStack[index + 1].GetComponent<BackpackBlock>();
            BackpackBlock current = blockStack[index].GetComponent<BackpackBlock>();
            
            if (previous.color == current.color && (previous.matched || next.color==current.color))
            {
                match = true;                             //match this and
                GetMatched(index + 1, true); //propagate the found match forward
            }
            //if not even that is true (no new match and not continuing a previous match) no more recursive
        }
        print(match);
        return match; //propagate result backwards
    }*/

    public void GetMatched() //the new and improved solution to the above failure
    {
        if (blockStack.Count<3) return;  //can't spell 'match 3' without '3'
        BackpackBlock previous;
        BackpackBlock current = blockStack[0].GetComponent<BackpackBlock>();
        BackpackBlock next = blockStack[1].GetComponent<BackpackBlock>(); //these look weird but they set up the loop to start seamlessly
        bool flag = false;                                                 //no matches until proven otherwise
        for (int i = 2; i < blockStack.Count; i++)                          //start traveling down the list
        {
            previous = current;
            current = next;
            next = blockStack[i].GetComponent<BackpackBlock>();                 //shift along the stack, looking at 3 at a time
            if (previous.color == current.color && current.color == next.color) //if all 3 match in color
            {
                previous.matched = true;
                current.matched = true;
                next.matched = true;
                flag = true;                                                    //then they're all matched (even if they already were) and we have matches
            }
        }

        foreach (GameObject block in blockStack)
        {
            block.GetComponent<BackpackBlock>().MatchDestroy();                 //ask everything to please die if already matched
        }

        if (flag) StartCoroutine(CleanAndMatch());                         //if matches are found, more might exist now
        else Crossroad.goal.ResolveScore();                                     //otherwise, time to assess this batch's score!
    }
}

public enum BlockColor
{
    Nil = -1, //clumsy null value
    Red = 0,
    Green = 1,
    Blue = 2
}