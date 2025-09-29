using UnityEngine;
using UnityEngine.TextCore.Text;

public class MoveComponent : MonoBehaviour
{
    public CharacterController controller;

    public float MaxWalkSpeed = 10f;
    public float WalkAccel = 80f;
    public float WalkDeccel = 150f;

    public float JumpVelocity = 15f;
    public float GravityAccel = 30f;

    public Vector2 MoveDirection;
    public Vector3 CurrentWalkVelocity { get; private set; } = Vector3.zero;
    private float _gravityVelocity = 0;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 targetWalkDirection = (transform.forward * MoveDirection.y + transform.right * MoveDirection.x).normalized;
        Vector3 targetWalkVelocity = targetWalkDirection * MaxWalkSpeed;

        CurrentWalkVelocity = Vector3.MoveTowards(CurrentWalkVelocity, targetWalkVelocity, GetWalkAccelValue() * Time.deltaTime);

        // gravity
        if (controller.isGrounded && _gravityVelocity < 0) _gravityVelocity = 0;
        _gravityVelocity -= GravityAccel * Time.deltaTime;
        Vector3 gravityVel = Vector3.up * _gravityVelocity;

        Vector3 moveVelocity = CurrentWalkVelocity + gravityVel;
        controller.Move(moveVelocity * Time.deltaTime);
    }

    public bool IsOnGround()
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
            if (MoveDirection.sqrMagnitude == 0f)
            {
                return WalkDeccel;
            }
            else if (Vector3.Dot(MoveDirection, CurrentWalkVelocity) < 0)
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
            return WalkAccel * (1f / 5f);
        }

    }

    public void Jump()
    {
        _gravityVelocity = JumpVelocity;
    }

}
