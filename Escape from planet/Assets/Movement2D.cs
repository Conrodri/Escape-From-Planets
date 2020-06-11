using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    public Rigidbody2D rb;
    float moveSpeed = 10;
    public bool isGrounded;
    public LayerMask groundLayer;
    private SpriteRenderer PlayerSpriteRenderer;
    Vector2 movement;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.15f, transform.position.y - 0.15f),
           new Vector2(transform.position.x + 0.15f, transform.position.y - 0.15f), groundLayer);
        // Move player
        transform.Translate(new Vector2(Input.GetAxis("Horizontal"), 0f) * moveSpeed * Time.deltaTime);

        // Flip player
        PlayerSpriteRenderer = GetComponent<SpriteRenderer>();
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        Vector3 playerDirection = transform.localScale;
        if (movement.x < 0)
        {
            PlayerSpriteRenderer.flipX = true;
        }
        if (movement.x > 0)
        {
            PlayerSpriteRenderer.flipX = false;
        }
        transform.localScale = playerDirection;
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        }
    }
}
