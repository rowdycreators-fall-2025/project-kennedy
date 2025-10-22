using UnityEngine;
using UnityEngine.InputSystem;

public class GunHolder : MonoBehaviour
{
    public Gun CurrentGun { get; private set; } = null;
    public float MaxShootRange = 100.0f;

    private PlayerInputActions inputActions;


    private void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.Enable();
        SetGun(new Gun());
    }

    public void SetGun(Gun gun)
    {
        CurrentGun = gun;
        if (gun != null)
        {
            Debug.Log("yes gun");
            inputActions.Combat.Attack.started += Shoot;
        }
        else
        {
            Debug.Log("no gun");
            inputActions.Combat.Attack.started -= Shoot;
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        Debug.Log("shooting");

        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, MaxShootRange);
        if (hit.collider == null) { return; }

        Shootable shootable = hit.collider.GetComponent<Shootable>();
        if (shootable == null) { return; }

        shootable.Shoot(5);
    }
}
