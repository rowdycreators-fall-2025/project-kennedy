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

        if (gun.hitEnemy)
        {
            enemy.health -= gun.damage;
            if (enemy.health <= 0.0f) 
            {
                enemy.Die();
            }

            stateMachine.ChangeState(new HurtState());
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
