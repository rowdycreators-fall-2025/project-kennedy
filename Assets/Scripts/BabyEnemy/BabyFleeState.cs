using UnityEngine;

public class BabyFleeState : State
{
    private Transform _fleePoint;
    private float _fleeSpeed;
    private MoveComponent _move;

    public BabyFleeState(StateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("entered BabyFleeState");

        _fleePoint = ((BabyEnemyStateMachine)_stateMachine)._fleePoint;
        _fleeSpeed = ((BabyEnemyStateMachine)_stateMachine)._fleeSpeed;
        _move = _stateMachine.GetComponent<MoveComponent>();

        _move.enabled = true;
    }


    public override void Update()
    {
        Vector3 translation = _fleePoint.position - _stateMachine.transform.position;
        _move.MoveDirection = new Vector2(translation.x, translation.z).normalized;
    }

    public override void Exit()
    {
        _move.MoveDirection = Vector2.zero;
        _move.enabled = false;

        Debug.Log("exited BabyFleeState");
    }
}
