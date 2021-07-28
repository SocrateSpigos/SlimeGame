using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MultipliersTargets : MonoBehaviour
{
    public float multiplier;

    public TextMeshProUGUI tmp;
    public MeshRenderer rend;

    public void Config(int multi) //configure the multiplier zone's color, multiplier, text and cooridnates
    {
        this.transform.Translate(new Vector3(0, -1, multi*4));
        multiplier = multi;
        rend.material = Crossroad.mats[multi % Crossroad.mats.Length];
        tmp.text = "X" + multi;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Crossroad.multiplierFLag)
        {
            if (!Crossroad.multiplierFLag) return;
            Crossroad.multiplierFLag = false; //make sure the player doesn't cross two multipliers
            Crossroad.score *= multiplier;    //and multiply the score
        }
    }
}
