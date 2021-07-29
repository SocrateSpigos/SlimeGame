using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator anim;

    void Awake ()
    {
        anim = GetComponent<Animator>();
    }

    public void Run(bool Run)
    {
        anim.SetBool("Run", Run);
    }

    
}
