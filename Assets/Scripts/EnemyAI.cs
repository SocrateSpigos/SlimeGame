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
    public Animator enemyAnim;
    public PlayerHP playerHp;
    public EnemyHP enemyHp;
    public int damage;
    private bool takeDamage =false;
    private GameObject player;
    public Animator damageAnim;


    public float range = 5f;


    void Start()
    {


        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        enemyAnim = GetComponent<Animator>();
       
       /* player = GameObject.Find("Player");
        target = player.transform.Find("Player");*/

    }

  

    void Update()
    {
       // target = player.transform.Find("Player");
       // Debug.Log(target.transform.position);


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

            InvokeRepeating("Damaged", 0, 1f);
        }

        /*if(other.tag == "Bullet")
        {
            Debug.Log("Die");
            enemyAnim.SetBool("Die",true);
        }*/

    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Character")
        {



        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Character")
        {

            anim.SetBool("Attack", false);
            anim.SetBool("Walk", true);

            CancelInvoke("Damaged");
            damageAnim.SetBool("Damage", false);


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
            damageAnim.SetBool("Damage", false);


        }
    }

    IEnumerator CopCoroutine()
    {

        yield return new WaitForSeconds(2f);
        playerHp.TakeDamage(5);
    }

    public void Damaged()
    {
        playerHp.TakeDamage(damage);
        damageAnim.SetBool("Damage", true);


    }
}
