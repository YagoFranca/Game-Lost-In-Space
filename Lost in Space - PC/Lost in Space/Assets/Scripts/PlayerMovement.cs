using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

     
    public CharacterController2D controller;
    public Animator animator;
    private SpriteRenderer sr;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    private bool invencivel;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Enemy" && !invencivel)
        {
            Dados.vidas--;
            StartCoroutine(Invencivel());
         
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    IEnumerator Invencivel()
    {
        invencivel = true;

        for (int i = 0; i < 3; i++)
        {
            sr.enabled = false;
            yield return new WaitForSeconds(0.3f);
            sr.enabled = true;
            yield return new WaitForSeconds(0.3f);
        }

        invencivel = false;
    }
}


