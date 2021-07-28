using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackBlock : MonoBehaviour
{
    public BlockColor color;
    public bool matched = false;

    //scale down
    public Vector3 StartingScale;
    private bool Shrink;
    public float Decreaser = 1;
    public Transform DestructionParticle;

    private Color[] col = new Color[] {Color.red,Color.green,Color.blue};

    public void Start()
    {
        StartingScale = transform.localScale;
    }

    public void Config(BlockColor inputColor)//configure your color
    {
        color = inputColor;
        Crossroad.backpackManager.AddBlock(this.gameObject);
    }

    public void GotRemoved()
    {
        DestructionParticle.GetComponentInChildren<ParticleSystem>().startColor = transform.GetComponent<Renderer>().material.color;
        Instantiate(DestructionParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void GotMatched() //this is unused, I believe, but I won't remove it if I'm not there to fix it
    {
        Shrink=true;
        matched = true;
        //TODO a little song and dance
        //TODO update the score
        //TODO end said dance by destroy
        //StartCoroutine(DestroyDelay()); //temporary destroy that would ruin said dance
    }

    public void MatchDestroy()
    {
        if (matched)
        {
            Shrink = true;
    
            Crossroad.goal.ReportMatch(color);
        }
    }

    public void Update()
    {

        if (Vector3.Distance(transform.localScale, StartingScale) > 0.1f)
        {
            DestructionParticle.GetComponentInChildren<ParticleSystem>().startColor = transform.GetComponent<Renderer>().material.color;
            Instantiate(DestructionParticle, transform.position, Quaternion.identity);
    
            Destroy(gameObject);


        }
        else
        {
            if (Shrink)
            {

                transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0, 0, 0), Time.deltaTime * 5);
            }
        }


    }


    
}
