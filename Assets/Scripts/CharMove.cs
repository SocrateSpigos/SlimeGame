using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
    public float movespeed = 3;
    public static bool start = false;
    public float MoveSpeedSide;
    public float bounds;
    public GameObject character;

    public Animator[] Anims;

    public Transform Models;

    public Transform LookAt;

    private Touch touch;
    private Vector3 lastMousePos;
    private float maxNormSwipe = 15f;
    public float x;
    public float ForceMax;
    public Transform HoverboardPos;

    private void Start() //you know this code better than I do - it's yours!
    {
        start = false;
        StartGame();//TODO hook this up to start menu instead
        //Anims = Models.GetComponentsInChildren<Animator>();
    }

    public void StartGame()
    {
        StartCoroutine(Delay());
    }

    private void Update()
    {
       
        
        if (start)
        {
           transform.Translate(Time.deltaTime*movespeed*Vector3.forward);
            transform.GetComponent<CapsuleCollider>().center =new Vector3(0,transform.GetChild(1).position.y +1f ,0);
            if (Input.GetMouseButtonDown(0))
            {
                lastMousePos = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                Vector3 touch = Input.mousePosition;
                float delta = touch.x - lastMousePos.x;
                float swipeNorm = (delta / (Screen.width / 2)) * maxNormSwipe;
                swipeNorm = Mathf.Clamp(swipeNorm, -maxNormSwipe, maxNormSwipe);

                MoveSpeedSide = 3;
                character.transform.position = Vector3.Lerp(
                   character.transform.position,
                   new Vector3(character.transform.position.x + swipeNorm, character.transform.position.y, character.transform.position.z),
                   Time.deltaTime * MoveSpeedSide);

                LookAt.transform.position = Vector3.Lerp(
                    LookAt.transform.position,
                    new Vector3(character.transform.position.x + swipeNorm, LookAt.transform.position.y, LookAt.transform.position.z),
                    Time.deltaTime * 2000);

                if (character.transform.position.x < -bounds)
                {
                    character.transform.position = new Vector3(-bounds, character.transform.position.y, character.transform.position.z);

                }
                if (character.transform.position.x > bounds)
                {
                    character.transform.position = new Vector3(bounds, character.transform.position.y, character.transform.position.z);

                }
                if (LookAt.transform.position.x < -bounds)
                {
                    LookAt.transform.position = new Vector3(-bounds, LookAt.transform.position.y, LookAt.transform.position.z);

                }
                if (LookAt.transform.position.x > bounds)
                {
                    LookAt.transform.position = new Vector3(bounds, LookAt.transform.position.y, LookAt.transform.position.z);

                }
                lastMousePos = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(0))
            {

                LookAt.transform.position = new Vector3(character.transform.position.x  , LookAt.transform.position.y, character.transform.position.z + 3.86f);
            }

        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        start = true;
        foreach (Animator Anim in Anims)
        {
            Anim.SetBool("Run", true);
        }

    }
}
