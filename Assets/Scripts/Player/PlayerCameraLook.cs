using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraLook : MonoBehaviour
{
    public Transform player;
    public bool CamEnabled = true;

    [Header("Sensitivity")]
    public float ySensitivity = 0.25f;
    public float xSensitivity = 0.25f;

    private float _xRotation;
    private float _yRotation;

    private bool _cursorLocked = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _cursorLocked = true;
    }

    void Update()
    {
        player.rotation = Quaternion.Euler(0, _yRotation, 0); // rotate parent player
        transform.localRotation = Quaternion.Euler(_xRotation, 0, 0); // then rotate up/down

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
