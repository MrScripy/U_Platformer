using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementTest : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveVector;
    [SerializeField] float speed = 3f;
    [SerializeField] float jumpForce = 3f;

    private bool onGround;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private float checkRadius = 0.5f;
    public LayerMask Ground;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Walk();
        CheckingGround();
        Jump();
    }


    private void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        // movement without physics
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
        // movement with physics
        //rb.AddForce(moveVector * speed);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }

    private void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
    }

}
