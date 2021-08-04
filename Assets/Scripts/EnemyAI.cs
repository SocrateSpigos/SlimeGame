using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;
    public float rotationSpeed = 5;
    private Rigidbody rb;
    private Animator anim;
    public PlayerHP playerHp;
    public int damage;
    private bool takeDamage =false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        
    }


    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), rotationSpeed * Time.deltaTime);
        transform.position += transform.forward * Time.deltaTime * moveSpeed;

        PlayerDeath();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Character")
        {
            anim.SetBool("Attack", true);
            anim.SetBool("Walk", false);
        }

    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Character")
        {

            playerHp.TakeDamage(1);


        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Character")
        {

            anim.SetBool("Attack", false);
            anim.SetBool("Walk", true);
        }
    }

    void PlayerDeath()
    {
        if (playerHp.currentHealth <=0)
        {
            anim.SetBool("Victory", true);
            anim.SetBool("Attack", false);
            anim.SetBool("Walk", false);
            moveSpeed = 0;

        }
    }

    IEnumerator CopCoroutine()
    {

        yield return new WaitForSeconds(2f);
        playerHp.TakeDamage(5);
    }

}
