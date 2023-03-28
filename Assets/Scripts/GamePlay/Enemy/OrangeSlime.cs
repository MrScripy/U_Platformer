using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharAttack))]
public class OrangeSlime : Character
{
    [Header("Attack")]
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float attackRadius;
    [SerializeField] private Transform attackPoint;
    [Header("Move")]
    [SerializeField] private Transform firstStopPoint;
    [SerializeField] private Transform secondStopPoint;
    [SerializeField, Range(1f, 5f)] private float speed;
    [Header("ParticleSystem")]
    [SerializeField] private ParticleSystem particle;


    private Vector3 target;
    private CharAttack charAttack;
    private float nextAttackTime = 5f;

    private void Start()
    {
        charAttack = GetComponent<CharAttack>();
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
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(transform.position, attackRadius, playerMask);
            foreach (var player in hitPlayer)
                charAttack.PerformAttack(player.GetComponent<CharDamagable>());
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
