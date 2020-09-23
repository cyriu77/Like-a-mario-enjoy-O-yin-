using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 direction;
    public float speed = 8;
    public float jumpForce = 10;
    public float gravity = -20;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool ableToMakeDoubleJump = true;
    public Animator animator;
    public Transform model;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.gameOver)
        {
            //player animation
            animator.SetTrigger("Die");
            //player death(disable script)
            this.enabled = false;
        }
        float hInput = Input.GetAxis("Horizontal");
        direction.x = hInput * speed;

        animator.SetFloat("speed", Mathf.Abs(hInput));
        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);
        if(isGrounded)
        {
            direction.y = -1;
            
            ableToMakeDoubleJump = true;
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        if(Input.GetKeyDown(KeyCode.F))
            {
                animator.SetTrigger("Throw Object Attack");
            }
        }else
        {
            direction.y += gravity * Time.deltaTime;

            if (ableToMakeDoubleJump & Input.GetButtonDown("Jump"))
            {
                DoubleJump();
            }
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Throw Object Attack"))
            return;

        if(hInput != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(hInput,0,0));
            model.rotation = newRotation;
        }
       
        controller.Move(direction * Time.deltaTime);
        if(transform.position.z != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0); 
        }
    }
    private void DoubleJump()
    {
        animator.SetTrigger("doubleJump");
        direction.y = jumpForce;
        ableToMakeDoubleJump = false;
    }
    private void Jump()
    {
        direction.y = jumpForce;
    }
}
