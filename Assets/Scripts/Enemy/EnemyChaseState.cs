using UnityEngine;

// Enemy Chase State inherits the State class of type enemy
public class EnemyChaseState : State
{
    // constructer for EnemyChaseState, takes a StateMachine as a parameter, and sets the StateMachine type as the owner of the base class (State)
    public EnemyChaseState(StateMachine enemyStateMachine) : base(enemyStateMachine) { }


    // function Enter is called when the State first enters
    public override void Enter()
    {
        // message that states the State has entered (for debugging purposes)
        Debug.Log("Enemy has entered the Chase State");
    }

    // Update function that contains the actual logic of the State, called every frame
    public override void Update()
    {
        // NOTE: temporary logic for the Chase State
        // will switch do the Idle State if up arrow key is pressed
        if (Input.GetKeyDown(KeyCode.DownArrow) == true)
        {
            _stateMachine.ChangeState(new EnemyIdleState(_stateMachine));
        }
    }

    // function Exit is called when the State leaves
    public override void Exit()
    {
        // message that state the State has been exited (for debugging purposes)
        Debug.Log("Enemy has exited the Chase State");
    }
}
