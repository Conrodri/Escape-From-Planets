using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHolder : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject myPlayer;
    Move2D playerScript;

    public bool isJumping = false;
    public bool isFullCharged = false;

    
    public float chargedPower = 10;
    public float maxChargePower = 20;
    public float Force = 50f;

    public bool canJump = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerScript = myPlayer.GetComponent<Move2D>();
    }

    void Update()
    {

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

            isFullCharged = false;
            animator.SetBool("IsFullCharged", false);
            animator.SetBool("IsCharging", false);
            canJump = false;
        }

       if (isJumping == true && Input.GetKeyUp(KeyCode.Space) && canJump == false && playerScript.isGrounded == true)
        {
            rb.AddForce(new Vector3(Input.GetAxis("Horizontal") * 0.35f, 1, 0) * chargedPower * Force);
            chargedPower = 10;
        }
    }
}
