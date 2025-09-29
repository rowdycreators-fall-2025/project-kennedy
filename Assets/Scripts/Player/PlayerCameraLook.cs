using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraLook : MonoBehaviour
{

    public Transform player;
    private CharacterController _character;
    public bool CamEnabled = true;
    public bool BobEnabled = true;

    public float ySensitivity = 0.25f;
    public float xSensitivity = 0.25f;

    private float _xRotation;
    private float _yRotation;

    private Vector3 _startPos;
    public float _bobStepFrequency = 10;
    public float _bobStepAmplitude = 0.01f;

    private bool _cursorLocked = false;

    void Start()
    {
        _character = player.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        _cursorLocked = true;
        _startPos = transform.localPosition;
    }

    void Update()
    {
        player.rotation = Quaternion.Euler(0, _yRotation, 0); // rotate parent player
        transform.localRotation = Quaternion.Euler(_xRotation, 0, 0); // then rotate up/down

        if (!BobEnabled) return;
        float characterSpeed = new Vector3(_character.velocity.x, 0, _character.velocity.z).magnitude;

        if (characterSpeed > 0)
        {
            Vector3 stepPos = Vector3.zero;
            stepPos.x += Mathf.Cos(Time.time * _bobStepFrequency) * _bobStepAmplitude;
            stepPos.y += Mathf.Sin(Time.time * _bobStepFrequency * 2) * _bobStepAmplitude;
            transform.localPosition += stepPos;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, 1f - Mathf.Pow(.01f, Time.deltaTime));
        if (Mathf.Abs(transform.forward.y) < .9f) // gaurds from bug where rotation changes when looking down/up
            transform.LookAt(player.position + transform.forward * 15f);

        PerformRaycastAtCrosshair();
    }

    void PerformRaycastAtCrosshair()
    {
        // Calculates the center of the screen in pixel coordinates
        // Screen.width and Screen.height give the current screen resolution
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);

        // raycasts forward at screen center
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        // Using the ray for a RaycastHit
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // If the ray hits something, you can access 'hit.collider.gameObject', 'hit.point', etc.
            GameObject hitObject = hit.collider.gameObject;

            Debug.Log("Ray hit: " + hitObject.name + " at " + hit.point); // debug

            Interactable interactionInterface;
            if (interactionInterface = hitObject.GetComponent<Interactable>())
            {
                interactionInterface.OnHover();
            }
        }
    }

    public void OnCameraPan(InputAction.CallbackContext context)
    {
        if (!_cursorLocked) return;
        Vector2 delta = context.ReadValue<Vector2>();
        _xRotation = Mathf.Clamp(_xRotation - delta.y * ySensitivity, -90, 90);
        _yRotation += delta.x * xSensitivity;

    }

    public void OnCamLock(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            _cursorLocked = !_cursorLocked;
            Cursor.lockState = _cursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }
}
