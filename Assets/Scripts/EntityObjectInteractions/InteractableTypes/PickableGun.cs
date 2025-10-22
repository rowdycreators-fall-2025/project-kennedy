using System;
using UnityEngine;

public class PickableGun : Interactable
{

    public Gun gun;
    public GameObject gunModel;


    protected override Type[] possibleActionTypes => new Type[] {
        typeof(PickupGunAction),
    };

    protected override void Start()
    {
        base.Start();
        gun = new Gun(5, gunModel);
    }


    public void PerformPickup(Interactor interactor)
    {
        interactor.GetComponent<GunHolder>().SetGun(gun);
        GameObject.Destroy(gameObject);
    }

}
