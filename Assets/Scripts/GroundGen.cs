using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class GroundGen : MonoBehaviour
{
    public GameObject[] pieces;                     //this is where track pieces go
    public GameObject track;                        //the parent of all tracks
    public GameObject finish;                       //the prefab dor the finish piece
    public bool done = false;                       //have we reached the finish?
    public bool spawnedFinish = false;              //placed it, too?

    private float segmentDistance = 1;                //constant to tweak as needed
    public float position = 0;                        //where we're building currently
    public int playerPosition = 0;
    public bool spawning = false;                   //currently building something?

    public GameObject finishLine;
    
    private void Start()
    {
        UnityEngine.Random.seed = System.DateTime.Now.Millisecond;
        for (int i = 0; i < 7; i++)                //track: starter kit!
        {
            spawning = true;
            StartCoroutine(SpawnObstacle());
        }
    }

    void Update()
    {
        if (track.transform.childCount > 10) return;    //keep enough pieces around to look good
        if (/*!spawning && */done && !spawnedFinish)    //if we need a finish
        {
            spawnedFinish = true;
            spawning = true;
            StartCoroutine(SpawnFinish());       //note we no longer do and spawn it
        }
        if (/*!spawning && */!done)                     //if still spawning
        {
            spawning = true;
            StartCoroutine(SpawnObstacle());    //spawn
        }
    }

    public void ReportFinish()                                  //get into finish-spawning mode!
    {
        if (spawnedFinish) return;                              //don't double down
        spawnedFinish = false;
        done = true;
        for (int i = 3; i < track.transform.childCount; i++)    //get rid of spare tracks
        {
            Destroy(track.transform.GetChild(i).gameObject);   //todo make it flashy
        }
    }
    IEnumerator SpawnFinish()
    {
        position = (int) (track.transform.GetChild(2).localPosition.z + track.transform.GetChild(2).GetChild(0).localScale.z); //spawn it at the right spot
        finishLine.transform.parent = track.transform;
        //GameObject finishLine = Instantiate(finish, track.transform);
        finishLine.transform.localPosition = new Vector3(0, 0, position);                                                  //the *right* spot
        finishLine.GetComponent<FinishConfig>().Trigger();
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator SpawnObstacle()                                                                                                 //drop a game stretch
    {
        GameObject empty1 = Instantiate(pieces[UnityEngine.Random.Range(0, pieces.Length)], track.transform); //random piece from the list
        empty1.transform.localPosition = new Vector3(0, 0, position);                                       //place it where it needs to go
        
        position += segmentDistance*  empty1.transform.GetChild(0).localScale.z;                           //note where the next one goes
        yield return new WaitForSeconds(0.5f);                                                                  //take a breath
        spawning = false;                                                                                       //greenlight more spawns
    }
}
