using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool upCheck;
    private bool rightCheck;
    private bool downCheck;

    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask pipeLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            rb.velocity = new Vector2(0, 0);

            // shut down the game and pop up game over screen
            GameManager.instance.gameActive = false;
            GameManager.instance.gameOverScreen.SetActive(true);

            // shut down player
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Player>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            GameManager.instance.AddScore();
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
