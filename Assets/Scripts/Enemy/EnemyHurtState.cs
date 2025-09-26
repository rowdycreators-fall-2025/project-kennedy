using UnityEngine;

// Enemy Hurt State inherits the State class of type enemy
public class EnemyHurtState : State
{
    // constructer for EnemyHurtState, takes a StateMachine as a parameter, and sets the StateMachine type as the owner of the base class (State)
    public EnemyHurtState(StateMachine enemyStateMachine) : base(enemyStateMachine) { }

    // function Enter is called when the State first enters
    public override void Enter()
    {
        Debug.Log("Enemy has entered the Hurt State");
    }

    // Update function that contains the actual logic of the State, called every frame
    public override void Update()
    {
        
    }


    // function Exit is called when the State leaves
    public override void Exit()
    {
        Debug.Log("Enemy has exited the Hurt State");
    }
}
