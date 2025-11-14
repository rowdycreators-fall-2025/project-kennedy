using UnityEngine;

public class BabyEnemyStateMachine : StateMachine
{
    protected void Start()
    {
        ChangeState(new BabyIdleState(this));
    }
}
