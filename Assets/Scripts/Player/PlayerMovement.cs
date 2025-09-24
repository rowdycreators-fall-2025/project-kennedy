using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _character;

    public float MaxWalkSpeed = 10f;
    public float WalkAccel = 80f;
    public float WalkDeccel = 150f;

    public float JumpVelocity = 15f;
    public float GravityAccel = 30f;

    public Vector3 currentWalkVelocity { get; private set; } = Vector3.zero;
    private Vector2 inputDirection;
    private float _gravityVelocity = 0;


    private void Start()
    {
        _character = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 targetWalkDirection  = transform.forward * inputDirection.y + transform.right * inputDirection.x;
        Vector3 targetWalkVelocity = targetWalkDirection * MaxWalkSpeed;

        currentWalkVelocity = Vector3.MoveTowards(currentWalkVelocity, targetWalkVelocity, GetWalkAccelValue() * Time.deltaTime);

        // gravity
        if (_character.isGrounded && _gravityVelocity < 0) _gravityVelocity = 0;
        _gravityVelocity -= GravityAccel * Time.deltaTime;
        Vector3 gravityVel = Vector3.up * _gravityVelocity;

        Vector3 moveVelocity = currentWalkVelocity + gravityVel;
        _character.Move(moveVelocity * Time.deltaTime);
    }

    bool IsOnGround()
    {
        // checks if shpere area at the bottom of the character collides with floor
        if (Physics.CheckSphere(transform.position - Vector3.up * .5f, .6f, LayerMask.GetMask("Default"))) return true;
        return false;
    }


    // gets the acceleration value used for different situations
    float GetWalkAccelValue()
    {
        if (IsOnGround())
        {
            if (inputDirection.sqrMagnitude == 0f)
            {
                return WalkDeccel;
            }
            else if (Vector3.Dot(inputDirection, currentWalkVelocity) < 0) 
            {
                return (WalkAccel + WalkDeccel);
            }
            else
            {
                return WalkAccel;
            }
        }
        else
        {
            return WalkAccel * (1f/5f);
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
            if (IsOnGround()) _gravityVelocity = JumpVelocity;
        }
    }
}
