using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupChangeCol : MonoBehaviour
{
    public Material Col;

    public Transform Par;
    public float t;
    public bool picked;
    // Start is called before the first frame update
    public void Start()
    {
        t = 0;
        Col = Par.GetComponent<Renderer>().material;
        transform.GetComponent<SkinnedMeshRenderer>().material = Col;

    }

    // Update is called once per frame
    void Update()
    {
        if (picked && t<100)
        {
            t += 10;
            transform.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(0, t);
        }
    }
}
