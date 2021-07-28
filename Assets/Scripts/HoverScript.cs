using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverScript : MonoBehaviour
{

    public Transform CornerPointFL;
    public Transform CornerPointFR;
    public Transform CornerPointBL;
    public Transform CornerPointBR;

    public LayerMask GroundLayer;
    public float FwdForce;
    public float Distance;
    public float StandardForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HeightRaycast(CornerPointFL, Vector3.down);
        HeightRaycast(CornerPointFR, Vector3.down);
        HeightRaycast(CornerPointBL, Vector3.down);
        HeightRaycast(CornerPointBR, Vector3.down);


        Debug.Log(Input.GetAxis("Vertical"));
         transform.GetComponent<Rigidbody>().AddForce(transform.right * Input.GetAxis("Vertical") * -FwdForce);
        transform.GetComponent<Rigidbody>().AddTorque(transform.forward * Input.GetAxis("Horizontal") * -FwdForce);
    }

    public void HeightRaycast(Transform Start , Vector3 Direction)
    {
        RaycastHit hit;

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(Start.transform.position , Vector3.down, out hit, Distance, GroundLayer))
        {
            Debug.DrawRay(Start.transform.position, Vector3.down* Distance, Color.red);
            transform.GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(0, (StandardForce + Mathf.Abs(Start.transform.position.y-hit.point.y)), 0), Start.transform.position,ForceMode.Force);
         


       
        }

    }



}
