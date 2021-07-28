using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcoSphere : MonoBehaviour
{
    Vector3 start = Vector3.zero;
    Vector3 end = new Vector3(1, 1, 1);
    float lerpTime = 0;
    public bool isShrink = false;
    //public Material Material1;
    public GameObject Icosphere;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Vacuum")
        {
            isShrink = true;
        }
    }

    void Update()
    {

        if (isShrink)
        {
            Shrink();
        }
    }

    public void Shrink()
    {
        transform.localScale = Vector3.Lerp(end, start, lerpTime);
        lerpTime += Time.deltaTime;
        Destroy(Icosphere);
        //Object.GetComponent<MeshRenderer>().material = Material1;


    }

}
