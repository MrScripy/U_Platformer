using System.Collections;
using UnityEngine;
[RequireComponent(typeof(CharAttack))]
public class GreenSlime : Character
{
    private CharAttack attack;
    [SerializeField] private float attackRate = 5f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private GameObject coinItem;
    private float nextAttackTime = 0;

    private void Start()
    {
        attack = GetComponent<CharAttack>();
        coinItem.SetActive(false);
    }
    public override void Death()
    {
        coinItem.SetActive(true);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Time.time >= nextAttackTime && collision.gameObject.CompareTag("Player"))
        {
            attack.PerformAttack(collision.gameObject.GetComponent<CharDamagable>());
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }
}
