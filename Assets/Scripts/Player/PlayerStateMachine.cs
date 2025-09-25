using Unity.VisualScripting;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    private void Start()
    {
        ChangeState(new PlayerWalkState(this));
    }
}
