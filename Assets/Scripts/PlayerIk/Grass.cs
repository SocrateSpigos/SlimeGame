using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{

    public GameObject[] Grasses;
    public int spread;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<BoingKit.BoingReactor>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetInactiveInRadius(float range)
    {
        foreach (GameObject tr in Grasses)
        {
            float distanceSqr = (transform.position - tr.transform.position).sqrMagnitude;
            if (distanceSqr < range/2)
                tr.gameObject.GetComponent<BoingKit.BoingReactor>().enabled = true;
            else
                tr.gameObject.GetComponent<BoingKit.BoingReactor>().enabled = false;


            if (distanceSqr < range * spread)
                tr.gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
            else
                tr.gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;

        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            transform.GetComponent<BoingKit.BoingReactor>().enabled = true;

        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            transform.GetComponent<BoingKit.BoingReactor>().enabled = false;

        }
    }

}
