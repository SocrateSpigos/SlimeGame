using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{

    public Material startMaterial;
    public Material hoverMaterial;

    void Start()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BluePrint")
        {
            //mouseOver = true;
            GetComponent<Renderer>().material = hoverMaterial;
            //Invoke("SetBackToNormal", 6f);

        }

        if (other.tag == "Normal")
        {
            //mouseOver = true;
            GetComponent<Renderer>().material = startMaterial;
        }

    }

    void OnMouseDown()
    {
        SetBackToNormal();
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "BluePrint")
        {

            //mouseOver = false;
            GetComponent<Renderer>().material = startMaterial;
        }
    }

     public void SetBackToNormal()
    {
        Debug.Log("Called");
        GetComponent<Renderer>().material = startMaterial;

    }

}
