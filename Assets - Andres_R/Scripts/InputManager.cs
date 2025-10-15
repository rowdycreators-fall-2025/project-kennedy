using UnityEngine;
using UnityEngine.InputSystem;

// Manages player input, and delegates movement and look actions to appropriate components
public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.WalkingActions walking;
    private PlayerMotor motor;
    private PlayerLook look;
    private Gun gun;
    void Awake()
    {

        playerInput = new PlayerInput();
        walking = playerInput.Walking;
        motor = GetComponent<PlayerMotor>();
        gun = GetComponentInChildren<Gun>();
        look = GetComponent<PlayerLook>();
        walking.Jump.performed += ctx => motor.Jump();
        walking.Shoot.performed += ctx => gun.Shoot();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        motor.ProcessMove(walking.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.ProcessLook(walking.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        walking.Enable();
    }

    private void OnDisable()
    {
        walking.Disable();
    }
}
