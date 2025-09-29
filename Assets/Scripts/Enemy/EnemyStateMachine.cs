using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    public Transform player;
    private void Start()
    {
        ChangeState(new EnemyIdleState(this));
    }
}
