using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePrint : MonoBehaviour
{
    RaycastHit hit;
    Vector3 movePoint;
    public GameObject prefab;
    public bool canBuild=true;
    private ChangeColour cc;
    private GameObject ter;

    void Start()
    {
        ter = GameObject.FindGameObjectWithTag("Terrain");
        ChangeColour cc = ter.GetComponent<ChangeColour>();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         
        if (Physics.Raycast(ray, out hit, 50000.0f))
         {
            transform.position = hit.point;
         }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Building" || other.tag =="Enemy" || other.tag == "Character" || other.tag == "UnBuildable" )
        {
            canBuild = false;
            Debug.Log("false");
        }
       

        if (other.tag == "Terrain" && other.tag != "UnBuildable")
        {
            canBuild = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Building" || other.tag == "Enemy" || other.tag == "Character")
        {
            canBuild = false;
            Debug.Log("false");
        }

        if (other.tag == "Terrain")
        {
            canBuild = true;
        }
    }


  /*  void OnTriggerExit(Collider other)
    {
        if (other.tag == "Building" || other.tag == "Enemy" || other.tag == "Character")
        {
            if (other.tag != "UnBuildable")
            {
                canBuild = true;
                Debug.Log("true");
            }


        }
    }*/

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
                //cc.SetBackToNormal();

                Destroy(gameObject);
                

            }
            else
            {
                //cc.SetBackToNormal();

                Destroy(gameObject);

            }
        }
    }
}
