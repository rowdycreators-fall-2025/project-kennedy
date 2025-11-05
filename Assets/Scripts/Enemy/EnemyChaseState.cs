using UnityEngine;
using UnityEngine.AI;

// Enemy Chase State inherits the State class of type enemy
public class EnemyChaseState : State
{
    // constructer for EnemyChaseState, takes a StateMachine as a parameter, and sets the StateMachine type as the owner of the base class (State)
    public EnemyChaseState(StateMachine enemyStateMachine) : base(enemyStateMachine) { }

    private NavMeshAgent navAgent;
    private Transform player;

    public override void Enter()
    {
        Debug.Log("Enemy has entered the Chase State");

        // set navAgent and player variables
        navAgent = _stateMachine.GetComponent<NavMeshAgent>();
        player = ((EnemyStateMachine) _stateMachine).player; // cast StateMachine to EnemyStateMachine to access player attribute

        navAgent.enabled = true;
        navAgent.SetDestination(player.position);
    }


    public override void Update()
    {
        // NOTE: temporary logic for the Chase State
        // will switch do the Idle State if up arrow key is pressed
        if (Input.GetKeyDown(KeyCode.DownArrow) == true)
        {
            _stateMachine.ChangeState(new EnemyIdleState(_stateMachine));
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) == true)
        {
            _stateMachine.ChangeState(new EnemyChaseState(_stateMachine)); // restart cycle
        }

    }


    public override void Exit()
    {
        navAgent.SetDestination(_stateMachine.transform.position);

        Debug.Log("Enemy has exited the Chase State");
    }
}
