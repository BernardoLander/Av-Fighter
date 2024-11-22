using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private string inputNameHorizontal;
    [SerializeField] private string inputNameJump;
    [SerializeField] private string inputNameDash;

    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;
    bool dash = false;

    public Animator animator;

    void Start()
    {
        Debug.Log(inputNameDash + "\n" + inputNameHorizontal + "\n" + inputNameJump);
    }


    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw(inputNameHorizontal) * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown(inputNameJump))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }

        if (Input.GetButtonDown(inputNameDash))
        {
            Debug.Log("Dash pressed");
            dash = true;
        }

    }
    void FixedUpdate()
    {

        controller.Move(horizontalMove * Time.fixedDeltaTime , crouch, jump, dash);
        jump = false;
        crouch = false;
        dash = false;

    }
    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }

}
