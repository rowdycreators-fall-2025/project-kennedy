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
    }

    public void RemoveGun() => SetGun(null);

    public void SetGun(Gun gun)
    {
        CurrentGun = gun;
        if (gun != null)
        {
            Debug.Log($"added gun: {gun}");
            inputActions.Combat.Attack.started += Shoot;
            GameObject newGun = Instantiate(gun.gunModel, transform);
            newGun.transform.position = transform.TransformPoint(1f,-0.5f,1.5f);
            newGun.transform.localScale = new Vector3(.3f, .3f, .3f);
        }
        else
        {
            Debug.Log("removed gun");
            inputActions.Combat.Attack.started -= Shoot;
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        Debug.Log("shooting");

        RaycastHit hit;
        Physics.Raycast(transform.position, GetComponentInChildren<Camera>().transform.forward, out hit, MaxShootRange);
        if (hit.collider == null) { return; }

        Shootable shootable = hit.collider.GetComponent<Shootable>();
        if (shootable == null) { return; }

        shootable.Shoot(CurrentGun.ShootDamage);
    }
}
