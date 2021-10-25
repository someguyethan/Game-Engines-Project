using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            SceneManager.LoadScene("Defeat");
        if (collision.gameObject.tag != "Player")
            Destroy(collision.gameObject);
    }
}
