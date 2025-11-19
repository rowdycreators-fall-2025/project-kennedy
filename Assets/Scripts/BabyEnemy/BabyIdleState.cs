using UnityEngine;

public class BabyIdleState : State
{

    public BabyIdleState(StateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("entered BabyIdleState");
    }

    public override void Update()
    {
        
    }

    public override void Exit()
    {
        Debug.Log("exited BabyIdleState");
    }
}
