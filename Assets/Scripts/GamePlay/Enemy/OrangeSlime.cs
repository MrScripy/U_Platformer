using UnityEngine;

[RequireComponent(typeof(CharAttack))]
public class OrangeSlime : Character
{
    [Header("Attack")]
    [SerializeField] private CharAttack charAttack;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float attackRadius;
    [SerializeField] private Transform attackPoint;
    [Header("Move")]
    [SerializeField] private Transform firstStopPoint;
    [SerializeField] private Transform secondStopPoint;
    [SerializeField, Range(1f, 5f)] private float speed;
    [Header("ParticleSystem")]
    [SerializeField] private ParticleSystem particle;


    private Vector3 target;

    private float nextAttackTime = 5f;

    private void Start()
    {
        target = firstStopPoint.position;
    }

    private void Update()
    {
        Attack();
        Move();
    }


    private void Attack()
    {
        if (Time.time >= nextAttackTime)
        {
            CharacterAnimator.SetTrigger("IsAttacking");
            particle.Play();

            Collider2D hitPlayer = Physics2D.OverlapCircle(attackPoint.position, attackRadius, playerLayer);
            if (hitPlayer != null && hitPlayer.TryGetComponent<CharDamagable>(out CharDamagable playerDam))
                charAttack.PerformAttack(playerDam);

            nextAttackTime = Time.time + Random.Range(3, 10);
        }
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (target == firstStopPoint.position)
            target = secondStopPoint.position;
        else
            target = firstStopPoint.position;
    }

    public override void Death()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
