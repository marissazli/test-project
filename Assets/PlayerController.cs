using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 movementVector;
    private Rigidbody2D rb;
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
        if(collision.gameObject.CompareTag("Ground"))
        {
            // do something
            Debug.Log("Hello");
        }
        //JUMP ASSIGNMENT
        //1. ADD A JUMP BINDING TO PLAYER INPUT, BIND TO SPACE
        //2. WHEN THE SPACE BAR IS PRESSED, ADD AN UPWARD FORCE TO THE PLAYER
        void OnJump()
        {
            rb.AddForce(new Vector2(0, 100));
        }
    }
}
