using Unity.VisualScripting;
using UnityEngine;

// Enemy Attack State inherits the State class of type enemy
public class EnemyAttackState : State
{

    private const float COOLDOWN_TIME = 2;
    private float coolDownTimer = 0;

    private Transform player;

    public EnemyAttackState(StateMachine enemyStateMachine) : base(enemyStateMachine) { }
       

    public override void Enter()
    {
        Debug.Log("Enemy has entered the Attack State");

        player = ((EnemyStateMachine)_stateMachine).player;
    }

    public override void Update()
    {
        // guaranteed attack on first Update
        if (coolDownTimer <= 0)
        {
            float playerDistance = (_stateMachine.transform.position - player.position).magnitude;

            // if enemy cant reach player
            if (playerDistance > ((EnemyStateMachine)_stateMachine).attackReach)
            {
                _stateMachine.ChangeState(new EnemyChaseState(_stateMachine));
                return;
            }

            player.GetComponent<PlayerStateMachine>().Hit(10);
            coolDownTimer = COOLDOWN_TIME;
        }

        coolDownTimer -= Time.deltaTime;
    }

    // function Exit is called when the State leaves
    public override void Exit()
    {
        // message that state the State has been exited (for debugging purposes)
        Debug.Log("Enemy has exited the Attack State");
    }
}
