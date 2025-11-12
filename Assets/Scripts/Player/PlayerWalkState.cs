using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalkState : State
{
    PlayerInputActions actions = new PlayerInputActions();
    MoveComponent move;
    public PlayerWalkState(StateMachine stateMachine) : base(stateMachine)
    {
        move = stateMachine.GetComponent<MoveComponent>();

    }

    public override void Enter()
    {
        Debug.Log("entered state");
        actions.Walking.Enable();
        actions.Walking.Jump.started += OnJumpAction;
    }

    public override void Exit()
    {
        actions.Walking.Disable();
        actions.Walking.Jump.started -= OnJumpAction;
    }

    public override void Update()
    {
        move.MoveDirection = actions.Walking.Walk.ReadValue<Vector2>();
    }

    void OnJumpAction(InputAction.CallbackContext ctx)
    {
        if (move.IsOnGround()) move.Jump();
    }
}
