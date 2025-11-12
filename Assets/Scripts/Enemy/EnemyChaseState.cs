using UnityEngine;
using UnityEngine.AI;

// Enemy Chase State inherits the State class of type enemy
public class EnemyChaseState : State
{
    // constructer for EnemyChaseState, takes a StateMachine as a parameter, and sets the StateMachine type as the owner of the base class (State)
    public EnemyChaseState(StateMachine enemyStateMachine) : base(enemyStateMachine) { }

    private NavMeshAgent navAgent;
    private Transform player;

    private float navAgentRefreshRatePerSecond = 10;
    private float coolDownTimer = 0;

    public override void Enter()
    {
        Debug.Log("Enemy has entered the Chase State");

        navAgent = _stateMachine.GetComponent<NavMeshAgent>();
        player = ((EnemyStateMachine)_stateMachine).player;

        navAgent.enabled = true;
        navAgent.SetDestination(player.position);
    }


    public override void Update()
    {
        coolDownTimer += Time.deltaTime;

        if (coolDownTimer >= 1.0 / navAgentRefreshRatePerSecond)
        {
            coolDownTimer = coolDownTimer % (1f / navAgentRefreshRatePerSecond);
            navAgent.SetDestination(player.position);
        }


        float distanceToPlayer = (_stateMachine.transform.position - player.position).magnitude;
        // if enemy can reach player
        if (distanceToPlayer <= ((EnemyStateMachine)_stateMachine).attackReach)
        {
            _stateMachine.ChangeState(new EnemyAttackState(_stateMachine));
        }

    }


    public override void Exit()
    {
        navAgent.SetDestination(_stateMachine.transform.position);

        Debug.Log("Enemy has exited the Chase State");
    }
}
