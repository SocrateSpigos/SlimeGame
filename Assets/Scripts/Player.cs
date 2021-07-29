using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody myBody;
    public float moveForce = 10f;

    public VariableJoystick joystick;

    // private PlayerAnimation anim;
    public Animator anim;

    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        joystick = GameObject.FindWithTag("Joystick").GetComponent<VariableJoystick>();
        //anim = GetComponent<PlayerAnimation>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        myBody.velocity = new Vector3(joystick.Horizontal * moveForce, myBody.velocity.y,joystick.Vertical * moveForce);


        if (joystick.Horizontal !=0f || joystick.Vertical != 0f)
        {
            anim.SetBool("Run",true);
            anim.SetBool("Idle",false);

            transform.rotation = Quaternion.LookRotation(myBody.velocity);
        }
        else
        {
            anim.SetBool("Run", false);
            anim.SetBool("Idle", true);
        }



    }

}
