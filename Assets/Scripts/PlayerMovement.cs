using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public SpriteRenderer sr;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float groundDistance = 1f;

    public LayerMask groundMask;

    public float moveMultiplier = 1000f;
    public float jumpMultiplier = 1000f;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move ()
    {
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(new Vector2(-moveSpeed * moveMultiplier * Time.deltaTime, 0f), ForceMode2D.Force);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(new Vector2(moveSpeed * moveMultiplier * Time.deltaTime, 0f), ForceMode2D.Force);
        if (Input.GetKeyDown(KeyCode.Space) && CheckGround())
            rb.AddForce(new Vector2(0f, jumpForce * jumpMultiplier * Time.deltaTime), ForceMode2D.Impulse);

        if (rb.velocity.x < 0f)
            sr.flipX = true;
        else if (rb.velocity.x > 0f)
            sr.flipX = false;
    }

    bool CheckGround ()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundDistance, groundMask);
    }
}
