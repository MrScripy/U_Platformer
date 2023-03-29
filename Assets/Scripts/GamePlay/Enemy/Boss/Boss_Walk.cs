using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BossChar))]
[RequireComponent(typeof(CharAttack))]
public class Boss_Walk : StateMachineBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float attackRange = 3f;
    private Transform player;
    private Rigidbody2D bossRB;
    private BossChar boss;
    private CharAttack charAttack;
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bossRB = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<BossChar>();
        charAttack = animator.GetComponent<CharAttack>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, bossRB.position.y);
        Vector2 newPos = Vector2.MoveTowards(bossRB.position, target, speed * Time.fixedDeltaTime);
        bossRB.MovePosition(newPos);

        if (Vector2.Distance(player.position, bossRB.position) <= attackRange)
        {
            animator.SetTrigger("IsAttacking");            
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("IsAttacking");
    }


}
