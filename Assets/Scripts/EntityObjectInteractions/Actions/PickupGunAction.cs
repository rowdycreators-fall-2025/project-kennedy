using System.Linq;
using UnityEngine;

public class PickupGunAction : Action
{
    protected override string input => "Interaction";
    protected override string description => "Pickup";
    protected override bool isInstantAction => true;

    public PickupGunAction(Interactable interactableTarget) : base(interactableTarget) { }


    protected override void Start(Interactor interactor)
    {
        base.Start(interactor);
        ((PickableGun)interactableTarget).PerformPickup(interactor);
    }

    public override bool IsEligibleToBePerformedBy(Interactor interactor)
    {
        return true;
    }
}
