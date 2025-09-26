using UnityEngine;

// Enemy Dead State inherits the State class of type enemy
public class EnemyDeadState : State
{
    // constructer for EnemyDeadState, takes a StateMachine as a parameter, and sets the StateMachine type as the owner of the base class (State)
    public EnemyDeadState(StateMachine enemyStateMachine) : base(enemyStateMachine) { }

    // function Enter is called when the State first enters
    public override void Enter()
    {
        // message that states the State has entered (for debugging purposes)
        Debug.Log("Enemy has entered the Dead State");
    }

    // Update function that contains the actual logic of the State, called every frame
    public override void Update()
    {
        
    }

    // function Exit is called when the State leaves
    public override void Exit()
    {
        // Since we dont want the Enemy to leave the Dead State once entered, nothing will be in the Exit function
    }
}
