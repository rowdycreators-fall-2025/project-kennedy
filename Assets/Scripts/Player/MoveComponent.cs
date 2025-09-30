using UnityEngine;
using UnityEngine.TextCore.Text;

[RequireComponent(typeof(CharacterController))]
public class MoveComponent : MonoBehaviour
{
    private CharacterController _character;
    public Vector2 MoveDirection;

    [Header("Speed Values")]
    public float MaxWalkSpeed = 10f;
    public float WalkAccel = 80f; // acceleration to walk
    public float WalkDeccel = 150f; // acceleration to stop

    [Header("Jump Values")]
    public float JumpVelocity = 15f; // the velocity of agent's jump when jump button pressed
    public float GravityAccel = 30f; // the acceleration magnitude of gravity


    // current velocity at which agent is walking
    public Vector3 CurrentWalkVelocity { get; private set; } = Vector3.zero;
    private float _currentFallVelocity = 0;

    void Awake()
    {
        _character = GetComponent<CharacterController>();
    }

    void Update()
    {
        // gets target walk velocity from MoveDirection and local vectors
        Vector3 targetWalkDirection = transform.forward * MoveDirection.y + transform.right * MoveDirection.x;
        Vector3 targetWalkVelocity = targetWalkDirection * MaxWalkSpeed;

        // accelerates velocity toward target velocity
        CurrentWalkVelocity = Vector3.MoveTowards(CurrentWalkVelocity, targetWalkVelocity, GetWalkAccelValue() * Time.deltaTime);

        // gravity
        if (_character.isGrounded && _currentFallVelocity < 0) _currentFallVelocity = 0;
        _currentFallVelocity -= GravityAccel * Time.deltaTime;
        Vector3 gravityVel = Vector3.up * _currentFallVelocity;

        // move player by walk velocity + fall velocity
        Vector3 moveVelocity = CurrentWalkVelocity + gravityVel;
        _character.Move(moveVelocity * Time.deltaTime);
    }

    // checks if shpere area at the bottom of the character collides with floor
    public bool IsOnGround()
    {
        var position = transform.position - Vector3.up * .5f;
        var radius = .6f;
        var layerMask = LayerMask.GetMask("Default");

        if (Physics.CheckSphere(position, radius, layerMask)) return true;
        return false;
    }


    // gets the acceleration value used for different situations
    float GetWalkAccelValue()
    {
        if (IsOnGround())
        {
            if (MoveDirection.sqrMagnitude == 0f) // on ground and no player input
            {
                return WalkDeccel;
            }
            else if (Vector3.Dot(MoveDirection, CurrentWalkVelocity) < 0) // on ground and turning sharply
            {
                return (WalkAccel + WalkDeccel);
            }
            else // walking normally
            {
                return WalkAccel;
            }
        }
        else // in air
        {
            return WalkAccel * (1f / 5f);
        }

    }

    public void Jump()
    {
        _currentFallVelocity = JumpVelocity;
    }

}
