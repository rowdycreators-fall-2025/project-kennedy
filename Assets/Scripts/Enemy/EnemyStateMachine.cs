using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    private void Start()
    {
        ChangeState(new EnemyIdleState(this));
    }
}
