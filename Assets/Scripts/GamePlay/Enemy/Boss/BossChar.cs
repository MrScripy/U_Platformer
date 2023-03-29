using UnityEngine;

public class BossChar : Character
{
    [SerializeField] private Transform player;
    [SerializeField] private bool isFlipped;
    [SerializeField] private CharAttack charAttack;
    [SerializeField] private float attackRange = 3f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] Transform attackPoint;


    private Collider2D colInfo;

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public void Attack(float extraDamage)
    {
        colInfo = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);
        if (colInfo != null && colInfo.TryGetComponent<CharDamagable>(out CharDamagable playerDam))
            charAttack.PerformAttack(playerDam, extraDamage);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public override void Death()
    {
        Debug.Log("Open the portal");
    }

    public void BossDeathAnimationEvent()
    {
        this.gameObject.SetActive(false);
    }
}
