using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerChar player;
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
    private SpriteRenderer spriteR;
    private bool faceRight = true;
    #endregion
    #region Attack
    [Header("Attack")]
    [SerializeField] private CharAttack attack;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float attackRate = 2f;
    float nextAttackTime = 0f;
    #endregion
    private Rigidbody2D rb;
    private float moveHorizontal;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();
        realSpeed = speed;
    }
    public void PlayerMove()
    {
        CheckingGround();
        MyInput();
        Walk();
        Reflect();
        Run();
        Jump();
        if (Time.time >= nextAttackTime)
            Attack();
    }
    private void MyInput()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
    }
    private void Walk()
    {
        float move = Mathf.Abs(moveHorizontal);
        player.CharacterAnimator.SetFloat("Speed", move);
        if (move > 0.01f)
            transform.position += new Vector3(moveHorizontal, 0f, 0f) * realSpeed * Time.deltaTime;
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
            rb.AddForce(Vector2.up * jumpForce);
    }
    private void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
        player.CharacterAnimator.SetBool("OnGround", onGround);
    }
    private void Reflect()
    {
        if ((moveHorizontal > 0 && !faceRight) || (moveHorizontal < 0 && faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }
    private void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift) && onGround)
        {
            player.CharacterAnimator.SetBool("IsRunning", true);
            realSpeed = fastSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
                speedLock = true;
        }
        else
        {
            player.CharacterAnimator.SetBool("IsRunning", false);
            if (!speedLock)
                realSpeed = speed;
            else if (speedLock && onGround)
                speedLock = false;
            else
                realSpeed = fastSpeed;
        }
    }
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            player.CharacterAnimator.SetTrigger("IsAttacking");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
            foreach (var enemy in hitEnemies)
                attack.PerformAttack(enemy.GetComponent<CharDamagable>());
            nextAttackTime = Time.time + 1f / attackRate;
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
