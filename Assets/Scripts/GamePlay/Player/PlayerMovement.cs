using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{   
    #region Speed
    [Header("Speed")]
    [SerializeField] float speed = 5f;
    [SerializeField] float fastSpeed = 8f;
    private float realSpeed; 
    private bool speedLock;
    #endregion
    #region Jump
    [Header("Jump")]
    [SerializeField] float jumpForce = 350f;    
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private float checkRadius = 0.5f;
    [SerializeField] private LayerMask Ground;
    private bool onGround;
    #endregion
    #region Animation
    [Header("Animation")]
    [SerializeField] Animator animator;
    private SpriteRenderer spriteR;
    private bool faceRight = true;
    #endregion

    private Rigidbody2D rb;
    private float moveHorizontal;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();
        realSpeed = speed;
    }

    void Update()
    {
        CheckingGround();
        MyInput();
        Walk();
        Reflect();
        Run();
        Jump();
    }

    public void MyInput()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
    }

    public void Walk()
    {
        float move = Mathf.Abs(moveHorizontal);
        animator.SetFloat("Speed", move);
        if (move > 0.01f)
            transform.position += new Vector3(moveHorizontal, 0f, 0f) * realSpeed * Time.deltaTime;
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
            rb.AddForce(Vector2.up * jumpForce);
    }

    public void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
        animator.SetBool("OnGround", onGround);
    }

    private void Reflect()
    {
        if ((moveHorizontal > 0 && !faceRight) || (moveHorizontal < 0 && faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }

    public void Run()
    {
        if(Input.GetKey(KeyCode.LeftShift) && onGround)
        {
            animator.SetBool("IsRunning", true);
            realSpeed = fastSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
                speedLock = true;
        }
        else
        {
            animator.SetBool("IsRunning", false);
            if (!speedLock)
                realSpeed = speed;
            else if (speedLock && onGround)
                speedLock = false;
            else
                realSpeed = fastSpeed;
        }
    }
}
