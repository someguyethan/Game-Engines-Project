using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    public LayerMask groundMask;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move ()
    {
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(new Vector2(-moveSpeed, 0f), ForceMode2D.Force);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(new Vector2(moveSpeed, 0f), ForceMode2D.Force);
        if (Input.GetKeyDown(KeyCode.Space) && CheckGround())
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }

    bool CheckGround ()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundMask);
    }
}
