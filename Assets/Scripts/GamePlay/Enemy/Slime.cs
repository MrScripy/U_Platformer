using UnityEngine;

public class Slime : Character
{
    private CharAttack attack;
    [SerializeField] private float attackRate = 5f;
    [SerializeField] private LayerMask playerLayer;
    private float nextAttackTime = 0;

    private void Start()
    {
        attack = GetComponent<CharAttack>();
    }
    public override void Death()
    {
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Time.time >= nextAttackTime && collision.gameObject.tag == "Player")
        {
            attack.PerformAttack(collision.gameObject.GetComponent<CharDamagable>());
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

}
