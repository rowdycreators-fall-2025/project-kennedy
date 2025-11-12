using Unity.VisualScripting;
using UnityEngine;

// Enemy Attack State inherits the State class of type enemy
public class EnemyAttackState : State
{

    private const float COOLDOWN_TIME = 2;
    private float coolDownTimer = 0;

    private Transform player;

    // constructer for EnemyAttackState, takes a StateMachine as a parameter, and sets the StateMachine type as the owner of the base class (State)
    public EnemyAttackState(StateMachine enemyStateMachine) : base(enemyStateMachine) { }
       

    // function Enter is called when the State first enters
    public override void Enter()
    {
        // message that states the State has entered (for debugging purposes)
        Debug.Log("Enemy has entered the Attack State");

        player = ((EnemyStateMachine)_stateMachine).player;
    }

    // Update function that contains the actual logic of the State, called every frame
    public override void Update()
    {
        if (coolDownTimer <= 0)
        {
            float playerDistance = (_stateMachine.transform.position - player.position).magnitude;
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
