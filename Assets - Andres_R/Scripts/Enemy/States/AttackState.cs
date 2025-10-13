using UnityEngine;

public class AttackState : BaseState
{
    private float losePlayerTimer;
    public override void Enter()
    {
        
    }

    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;
        }
        else
        {
            losePlayerTimer += Time.deltaTime;
            if (losePlayerTimer > 5)
            {
                stateMachine.ChangeState(new IdleState());
            }
        }
    }

    public override void Exit()
    {
        
    }
}
