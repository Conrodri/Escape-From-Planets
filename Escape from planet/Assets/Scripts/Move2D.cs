using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class Move2D : MonoBehaviour
{
    public LayerMask groundLayer;
    public Animator animator;

    public float moveSpeed = 10;

    private float moveInput;

    public bool isGrounded = false;

    private SpriteRenderer PlayerSpriteRenderer;
    
    public Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PlayerSpriteRenderer = GetComponent<SpriteRenderer>();

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // check if is grounded or not
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.13f, transform.position.y - 0.13f),
           new Vector2(transform.position.x + 0.13f, transform.position.y - 0.13f), groundLayer);

        // Move player
        if (isGrounded == true)
        {
            animator.SetBool("IsGrounded", true);
            transform.Translate(new Vector2(Input.GetAxis("Horizontal"), 0f) * moveSpeed * Time.deltaTime);
        }

        else
        {
            isGrounded = false;
            animator.SetBool("IsGrounded", false);
        }

        // Flip player
        PlayerSpriteRenderer = GetComponent<SpriteRenderer>();
        
        if (movement.x < 0)
        {
            PlayerSpriteRenderer.flipX = true;
        }
        if (movement.x > 0)
        {
            PlayerSpriteRenderer.flipX = false;
        }
    }
}
