using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHolder : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject myPlayer;
    public GameObject canvas;
    public GameObject ProgressBar;
    ProgressJumpBar barScript;
    Move2D playerScript;

    public bool isJumping = false;
    public bool isFullCharged = false;

    
    public float chargedPower = 10;
    public float maxChargePower = 40;
    public float Force = 50f;

    public bool canJump = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerScript = myPlayer.GetComponent<Move2D>();
    }

    void Update()
    {
        barScript = ProgressBar.GetComponent<ProgressJumpBar>();

        // animation jump is grounding is true or not
        if (playerScript.isGrounded == true)
        {
            canJump = true;
            isJumping = false;
            animator.SetBool("IsJumping", false);
            animator.SetFloat("Speed", Mathf.Abs(playerScript.movement.x));
        }

        if (playerScript.isGrounded == false)
        {
            canJump = false;
            isJumping = true;
            animator.SetBool("IsJumping", true);
        }


        if ((Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Space)) && playerScript.isGrounded == true && canJump == true)
        {
            canvas.SetActive(true);
            animator.SetBool("IsCharging", true);
            chargedPower += Time.deltaTime * 11;
            if (chargedPower >= maxChargePower)
            {
                chargedPower = maxChargePower;
                animator.SetBool("IsCharging", false);
                isFullCharged = true;
                animator.SetBool("IsFullCharged", true);
            }
            playerScript.moveSpeed = 0;
        }

        if (Input.GetKeyUp(KeyCode.Space) && playerScript.isGrounded == true && canJump == true)
        {
            isJumping = true;
            animator.SetBool("IsJumping", true);
            if (isFullCharged == false)
                rb.AddForce(new Vector3(Input.GetAxis("Horizontal") * 0.5f, 0.75f, 0) * chargedPower * Force);
            else if (isFullCharged == true)
                rb.AddForce(new Vector3(Input.GetAxis("Horizontal") * 0.3f, 0.90f, 0) * chargedPower * Force);

            isFullCharged = false;
            animator.SetBool("IsFullCharged", false);
            animator.SetBool("IsCharging", false);
            canJump = false;
            canvas.SetActive(false);
            barScript.slider.value = 0;
            chargedPower = 10;
        }
    }
}
