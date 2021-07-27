using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePrint : MonoBehaviour
{
    RaycastHit hit;
    Vector3 movePoint;
    public GameObject prefab;
    public bool canBuild=true;

    void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         
        if (Physics.Raycast(ray, out hit, 50000.0f))
         {
            transform.position = hit.point;
         }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Building")
        {
            canBuild = false;
            Debug.Log("false");
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Building")
        {
            canBuild = true;
            Debug.Log("true");

        }
    }
    

    void Update()
    {


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         
        if (Physics.Raycast(ray, out hit, 50000.0f))
        {
            
                transform.position = hit.point;
            
        }

        if (Input.GetMouseButton(0))
        {
            if (canBuild)
            {
                Instantiate(prefab, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
