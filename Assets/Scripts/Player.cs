using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody myBody;
    public float moveForce = 500f;
    public VariableJoystick joystick;
    public Animator anim;
    private int currentHP;
    public ParticleSystem Coins;
    
    public GameObject levelingMenu;
    public GameObject joy;


    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Coins.Stop();

    }
    

    void Update()
    {
        PlayerHP playerHp = GetComponent<PlayerHP>();

        myBody.velocity = new Vector3(joystick.Horizontal * moveForce * Time.deltaTime, myBody.velocity.y,joystick.Vertical * moveForce *Time.deltaTime);

        if (playerHp.currentHealth > 0)
        {
            if (joystick.Horizontal != 0f || joystick.Vertical != 0f)
            {
                anim.SetBool("Run", true);
                anim.SetBool("Idle", false);

                transform.rotation = Quaternion.LookRotation(myBody.velocity);
            }
            else
            {
                anim.SetBool("Run", false);
                anim.SetBool("Idle", true);
            }

        }
        else
        {
            anim.SetBool("Die", true);
            moveForce = 0f;
        }

        if (levelingMenu.activeInHierarchy && playerHp.currentHealth > 0)
        {
            moveForce = 0f;

        }
        else
        {
            moveForce = 500f;

        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Refinery" && ScoreSystem.slimeScore > 2)
        {
            Coins.Play();
        }
        else
        {
            Coins.Stop();

        }
        
       /* if (other.tag == "levelingMenu" )
        {
            joy.SetActive(false);
            levelingMenu.SetActive(true);
            Time.timeScale = 0;

        }

        else
        {
            joy.SetActive(true);
            Time.timeScale = 1;
            levelingMenu.SetActive(false);

        }*/
    }


}
