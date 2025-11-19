using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalkState : State
{
    PlayerInputActions actions = new PlayerInputActions();
    MoveComponent move;
    private Gun gun;
    public PlayerWalkState(StateMachine stateMachine) : base(stateMachine)
    {
        move = stateMachine.GetComponent<MoveComponent>();
        gun = stateMachine.GetComponent<Gun>();
    }

    public override void Enter()
    {
        Debug.Log("entered PlayerWalkState");
        actions.Walking.Enable();
        actions.Walking.Jump.started += OnJumpAction;
        actions.Combat.Attack.started += OnAttackAction;
    }

    public override void Exit()
    {
        Debug.Log("exited PlayerWalkState");

        actions.Walking.Disable();
        actions.Combat.Disable();
        actions.Walking.Jump.started -= OnJumpAction;
        actions.Combat.Attack.started -= OnAttackAction;
    }

    public override void Update()
    {
        move.MoveDirection = actions.Walking.Walk.ReadValue<Vector2>();
    }

    void OnJumpAction(InputAction.CallbackContext ctx)
    {
        if (move.IsOnGround()) move.Jump();
    }

    void OnAttackAction(InputAction.CallbackContext ctx)
    {
        gun.Shoot();
    }
}
