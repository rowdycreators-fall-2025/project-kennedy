using UnityEngine;

public class HurtState : BaseState
{
    private float hurtTimer = 5f;
    public override void Enter()
    {
        enemy.health -= gun.damage;
        if (enemy.health <= 0.0f)
        {
            enemy.Die();
        }
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
        hurtTimer = 5f;
        gun.hitEnemy = false;
    }
}
