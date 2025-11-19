using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]
public class EnemyStateMachine : StateMachine
{
    public Gun gun;
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

        if (gun.hitEnemy)
        {
            Damage(gun.damage);
            gun.hitEnemy = false;
        }
    }

    public void Damage(float damage)
    {
        health -= damage;
        
        if (health <= 0f)
        {
            ChangeState(new EnemyDeadState(this));
        }
        else
        {
            ChangeState(new EnemyHurtState(this));
        }
    }

    public void SetChase()
    {
        ChangeState(new EnemyChaseState(this));
    }
}
