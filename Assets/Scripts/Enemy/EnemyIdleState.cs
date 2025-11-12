using UnityEngine;

// Enemy Idle State inherits the State of type Enemy
public class EnemyIdleState : State
{

    // constructer for EnemyIdleState, takes a StateMachine as a parameter, and sets the StateMachine type as the owner of the base class (State)
    public EnemyIdleState(StateMachine enemyStateMachine) : base(enemyStateMachine) { }


    // function Enter is called when the State first enters
    public override void Enter()
    {
        // message that states the State has entered (for debugging purposes)
        Debug.Log("Enemy has entered the Idle State");
    }

    // Update function that contains the actual logic of the State, called every frame
    public override void Update()
    {

    }

    // function Exit is called when the State leaves
    public override void Exit()
    {
        Debug.Log("Enemy has exited the Idle State");
    }
}