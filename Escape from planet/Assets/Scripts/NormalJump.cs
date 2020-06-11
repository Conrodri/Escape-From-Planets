using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalJump : MonoBehaviour
{
    public float jumpForce = 10;
    public float jumpTime;

    private float jumpTimeCounter;

    public GameObject myPlayer;
    Move2D playerScript;

    public Rigidbody2D rb;

    public bool isJumping;

    void Start()
    {
        playerScript = myPlayer.GetComponent<Move2D>();
    }

    void Update()
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && playerScript.isGrounded == true)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        // jumping higher while pressing long time
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        // start falling if u not press space anymore
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
}
