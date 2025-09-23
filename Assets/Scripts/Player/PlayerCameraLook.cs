using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraLook : MonoBehaviour
{

    public Transform player;

    public float ySensitivity = 1f;
    public float xSensitivity = 1f;

    private float xRotation;
    private float yRotation;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void OnCameraPan(InputAction.CallbackContext context)
    {
        Vector2 delta = context.ReadValue<Vector2>();
        xRotation = Mathf.Clamp(xRotation - delta.y * ySensitivity, -90, 90);
        yRotation += delta.x * xSensitivity;

        player.rotation = Quaternion.Euler(0, yRotation, 0);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
