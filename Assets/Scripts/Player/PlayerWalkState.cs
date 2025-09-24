using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalkState : State<GameObject>
{
    PlayerInputActions actions = new PlayerInputActions();
    MoveComponent move;
    public PlayerWalkState(GameObject owner) : base(owner) 
    {
        move = owner.GetComponent<MoveComponent>();

    }

    public override void Enter() 
    {
        Debug.Log("entered state");
        actions.Walking.Enable();
        actions.Walking.Jump.started += OnJump;
    }

    public override void Exit() 
    {
        actions.Walking.Disable();
        actions.Walking.Jump.started -= OnJump;
    }

    public override void Update()
    {
        move.MoveDirection = actions.Walking.Walk.ReadValue<Vector2>();
    }

    void OnJump(InputAction.CallbackContext ctx)
    {
        move.Jump();
    }
}
