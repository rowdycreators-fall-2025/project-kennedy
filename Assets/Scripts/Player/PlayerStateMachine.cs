using Unity.VisualScripting;
using UnityEngine;

public class PlayerStateMachine : StateMachine<GameObject>
{
    private void Start()
    {
        ChangeState(new PlayerWalkState(gameObject));
    }
}
