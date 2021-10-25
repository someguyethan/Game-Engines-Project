using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public SpriteRenderer sr;
    public Animator anim;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float groundDistance = 1f;

    public LayerMask groundMask;

    public float moveMultiplier;
    public float jumpMultiplier;

    public bool canMove = true;

    Vector2 movement;

    void Update()
    {
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.Space) && CheckGround())
                Jump();

            MyInput();

            if (rb.velocity.x > 0.1f || rb.velocity.x < -0.1f)
                anim.SetTrigger("isMoving");
            else
                anim.SetTrigger("isStill");

            if (rb.velocity.x < 0f)
                sr.flipX = true;
            else if (rb.velocity.x > 0f)
                sr.flipX = false;
        }
    }
    void FixedUpdate()
    {
        Move();
    }

    void Move ()
    {
        rb.AddForce(movement, ForceMode2D.Force);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(new Vector2(0f, jumpForce * jumpMultiplier * Time.deltaTime), ForceMode2D.Impulse);
    }
    void MyInput()
    {
        float xInput = Input.GetAxisRaw("Horizontal");

        movement = new Vector2(xInput * moveSpeed * moveMultiplier * Time.deltaTime, 0f);
    }    

    bool CheckGround ()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundDistance, groundMask);
    }
}
