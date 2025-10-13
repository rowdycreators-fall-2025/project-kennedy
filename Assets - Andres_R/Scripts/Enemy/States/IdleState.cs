using UnityEngine;

public class IdleState : BaseState
{
    public override void Enter()
    {
        
    }
    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new AttackState());
        }
    }
    public override void Exit()
    {
        
    }

    public void IdleCycle() 
    {
        //implement patrol logic
    }
}
