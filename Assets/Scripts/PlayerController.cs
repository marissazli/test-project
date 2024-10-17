using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 movementVector;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    [SerializeField] int speed = 0;
    private int score = 0;
    private SpriteRenderer sr;
    [SerializeField] Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = movementVector;

        rb.velocity = new Vector2(speed * movementVector.x, rb.velocity.y);
    }

    void OnMove(InputValue value)
    {
        movementVector = value.Get<Vector2>();


        Debug.Log(movementVector);
        animator.SetBool("Walk_Right", !Mathf.Approximately(movementVector.x, 0));
        if (!Mathf.Approximately(movementVector.x, 0))
        {
            sr.flipX = movementVector.x < 0;
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;

        }
    }
    //JUMP ASSIGNMENT
    //1. ADD A JUMP BINDING TO PLAYER INPUT, BIND TO SPACE
    //2. WHEN THE SPACE BAR IS PRESSED, ADD AN UPWARD FORCE TO THE PLAYER
    void OnJump()
    {
        if (isGrounded)
        {
            rb.AddForce(new Vector2(0, 300));
        }
    }
    void OnDash()
    {
        if (isGrounded)
        {
            animator.SetBool("Walk_Right", true);
            rb.AddForce(new Vector2(10000, 0));
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
            score++;
            Debug.Log("My score is: " + score);
        }
    }
}