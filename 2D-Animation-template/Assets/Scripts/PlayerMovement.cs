using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    public Animator animator;

    public void OnLand()
    {
        animator.SetBool("IsJumping", false);
//particles animatio
//soundsdfg dsfg
    }


    public void OnCrouchChanged(bool crouching)
    {
        animator.SetBool("IsCrouching", crouching);
    }

// Update is called once per frame
    void Update () {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
// 0 *40 = 0
// 1 * 40 = 40 -->
//-1 * 40 = -40 <--
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));



        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            animator.SetBool("IsCrouching", true);
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            animator.SetBool("IsCrouching", false);
        }

    }

    void FixedUpdate ()
    {
// Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}