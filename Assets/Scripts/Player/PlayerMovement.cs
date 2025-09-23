using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public CharacterController character;
    public float maxWalkSpeed;
    public float walkAccel;
    public float walkDeccel;

    public Vector3 currentWalkVelocity { get; private set; } = Vector3.zero;
    private Vector2 inputDirection;

    public float jumpVelocity = 15;
    public float Gravity = 10;
    private float yVelocity = 0;


    void Update()
    {
        Transform transform = GetComponent<Transform>();
        Vector3 targetWalkVelocity = transform.forward * inputDirection.y + transform.right * inputDirection.x;
        targetWalkVelocity *= maxWalkSpeed;

        currentWalkVelocity = Vector3.MoveTowards(currentWalkVelocity, targetWalkVelocity, GetWalkAccelValue() * Time.deltaTime);

        if (character.isGrounded && yVelocity < 0) yVelocity = 0;
        yVelocity -= Gravity * Time.deltaTime;
        Vector3 gravityVel = Vector3.up * yVelocity;

        Vector3 moveVelocity = currentWalkVelocity + gravityVel;

        character.Move(moveVelocity * Time.deltaTime);
    }

    bool IsOnGround()
    {
        if (Physics.CheckSphere(transform.position - Vector3.up, .1f, LayerMask.GetMask("Default"))) return true;
        return false;
    }


    float GetWalkAccelValue()
    {
        if (IsOnGround())
        {
            if (inputDirection.sqrMagnitude == 0f)
            {
                return walkDeccel;
            }
            else if (Vector3.Dot(inputDirection, currentWalkVelocity) < 0) 
            {
                return walkAccel * 2;
            }
            else
            {
                return walkAccel;
            }
        }
        else
        {
            return walkAccel;
        }

    }


    public void OnWalk(InputAction.CallbackContext context)
    {
        inputDirection = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (IsOnGround()) yVelocity = jumpVelocity;
        }
    }
}
