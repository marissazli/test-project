using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 movementVector;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    [SerializeField] int speed = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            rb.AddForce(new Vector2(0, 130));
        }
    }
    void OnDash()
    {
        if (isGrounded)
        {
            rb.AddForce(new Vector2(60, 0));
        }
    }
}