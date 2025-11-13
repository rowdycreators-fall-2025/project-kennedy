using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    public float health = 100;
    public float attackReach = 1.5f;

    public Transform player;
    public Animator spriteAnimator;

    public float cooldown_duration = 2;
    public float attackCooldownTimer = 0;


    private void Start()
    {
        ChangeState(new EnemyIdleState(this));
    }

    protected override void Update()
    {
        base.Update();

        attackCooldownTimer -= Time.deltaTime;
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
