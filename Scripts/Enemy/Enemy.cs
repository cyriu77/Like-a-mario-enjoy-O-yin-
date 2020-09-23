using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private string currentState = "IdleState";
    private Transform target;
    public float chaseRange = 5;
    public float attackRange = 2;
    public float speed = 3;

    public int health;
    public int maxHealth;

    public Animator animator;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        health = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.gameOver)
        {
            animator.enabled = false;
            this.enabled = false;
        }
        if (PlayerManager.gameOver)
        {
            animator.enabled = false;
            this.enabled = false;
        }
        float distance = Vector3.Distance(transform.position, target.position);
        if(currentState == "IdleState")
        {
            if(distance < chaseRange)
            {
                currentState = "ChaseState";
            }
        }
        else if(currentState == "ChaseState")
        {
            animator.SetTrigger("Chase");
            animator.SetBool("Attacking", false);
            if(distance < attackRange)
            {
                currentState = "AttackState";
            }

            if(target.position.x > transform.position.x)
            {
                //move right
                transform.Translate(transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }else
            {
                //move left
                transform.Translate(- transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        else if (currentState == "AttackState")
        {
            animator.SetBool("Attacking", true);
            if (distance > attackRange)
            {
                currentState = "ChaseState";
            }
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        currentState = "ChaseState";
        if (health < 0)
        {
            Die();
        }
    }
    public void Die()
    {
        //play a death animation
        animator.SetTrigger("Dead");
        // disable the script and collider
        GetComponent<CapsuleCollider>().enabled = false;
        this.enabled = false;
    }
}
