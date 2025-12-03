using UnityEngine;

public class BabyEnemyStateMachine : EnemyStateMachine
{

    public Transform _fleePoint;
    public float _fleeSpeed = 15;

    protected void Start()
    {
        ChangeState(new BabyIdleState(this));
    }

    public void SetFlee()
    {
        ChangeState(new BabyFleeState(this));
    }
}
