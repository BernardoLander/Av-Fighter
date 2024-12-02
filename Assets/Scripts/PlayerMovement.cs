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
    public float runSpeed = 60f;
    bool jump = false;
    bool crouch = false;
    bool dash = false;
    public float deathWaitTime = 1f;
    bool death = false;
    public Transform respawnPoint;
    public Transform playerTransform;

    public Animator animator;
    float direction = 1f;

    void Start()
    {
        Debug.Log(inputNameDash + "\n" + inputNameHorizontal + "\n" + inputNameJump);
    }


    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw(inputNameHorizontal) * runSpeed;
        direction = Input.GetAxisRaw(inputNameHorizontal);
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
        if (!death)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, dash, direction);
            jump = false;
            crouch = false;
            dash = false;
        }
        

    }
    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }
    public void Death(int DeathCounter)
    {
        Debug.Log("Recibido mensaje de muerte");
        StartCoroutine(deathHandler());
        if (DeathCounter < 3) 
        {
            Respawn();
        }
    }
    public IEnumerator deathHandler()
    {
        death = true;
        yield return new WaitForSeconds(deathWaitTime);
        death = false;
    }

    public void Respawn()
    {
        playerTransform.position = respawnPoint.position;
        
        Debug.Log("Death" + death);
        animator.SetBool("Death", false);
    }

}
