using Unity.VisualScripting;
using UnityEngine;

// Enemy Attack State inherits the State class of type enemy
public class EnemyAttackState : State
{

    private Transform player;
    private Animator spriteAnimator;

    public EnemyAttackState(StateMachine enemyStateMachine) : base(enemyStateMachine) { }
       

    public override void Enter()
    {
        Debug.Log("Enemy has entered the Attack State");

        player = ((EnemyStateMachine)_stateMachine).player;
        spriteAnimator = ((EnemyStateMachine)_stateMachine).spriteAnimator;

    }

    public override void Update()
    {
        float playerDistance = (_stateMachine.transform.position - player.position).magnitude;
        // if enemy cant reach player
        if (playerDistance > ((EnemyStateMachine)_stateMachine).attackReach)
        {
            _stateMachine.ChangeState(new EnemyChaseState(_stateMachine));
            return;
        }

        EnemyStateMachine agent = (EnemyStateMachine) _stateMachine;
        // guaranteed attack on first Update
        if (agent.attackCooldownTimer <= 0)
        {
            Debug.Log("attacked!!!");
            spriteAnimator.SetTrigger("attacked");

            player.GetComponent<PlayerStateMachine>().Hit(10);
            agent.attackCooldownTimer = agent.cooldown_duration;
        }
    }

    // function Exit is called when the State leaves
    public override void Exit()
    {
        // message that state the State has been exited (for debugging purposes)
        Debug.Log("Enemy has exited the Attack State");
    }
}
