using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCollapse : MonoBehaviour
{
    public GameObject PanelMenu;
    public GameObject Camera;
    public GameObject Joystick;
    public float Speed = 5f;

   public void ShowIdleMenu()
    {
        

        if (PanelMenu !=null)
        {

            Animator anim = PanelMenu.GetComponent<Animator>();
            Animator cam = Camera.GetComponent<Animator>();

            if(anim != null)
            {
                bool isOpen = anim.GetBool("show");

                anim.SetBool("show", !isOpen);
                cam.SetBool("show", !isOpen);
                Joystick.SetActive(isOpen);
            }

        }

    }

    
}
