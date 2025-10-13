using UnityEngine;

public class HurtState : BaseState
{
    private float hurtTimer = 5f;
    public override void Enter()
    {
        
    }

    public override void Perform()
    {
        hurtTimer -= Time.deltaTime;

        if (hurtTimer <= 0)
        {
            if (enemy.CanSeePlayer())
            {
                stateMachine.ChangeState(new AttackState());
            }
            else
            {
                stateMachine.ChangeState(new IdleState());
            }
        }

    }

    public override void Exit()
    {
        
    }
}
