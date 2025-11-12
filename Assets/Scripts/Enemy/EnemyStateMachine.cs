using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    public float health = 100;
    public float attackReach = 1.5f;

    public Transform player;
    private void Start()
    {
        ChangeState(new EnemyIdleState(this));
    }

    public void Damage(float damage)
    {
        health -= damage;
        ChangeState(new EnemyHurtState(this));

    }

    public void SetChase()
    {
        ChangeState(new EnemyChaseState(this));
    }
}
