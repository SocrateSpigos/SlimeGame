using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandCenter : MonoBehaviour
{

    public bool cM;

    void Start()
    {
        cM = true;
        ScoreSystem.goldScore -= 20;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
