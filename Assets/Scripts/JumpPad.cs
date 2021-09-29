using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float bounceForce = 10f;
    public float multi = 1000f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.rigidbody.AddForce(Vector2.up * bounceForce * multi * Time.deltaTime, ForceMode2D.Impulse);
    }
}
