using System;
using UnityEngine;
public class CloseDoorAction : Action
{
    protected override string input => "Interaction";
    protected override string description => "Close";
    protected override bool isInstantAction => true;

    public CloseDoorAction(Interactable interactableTarget) : base(interactableTarget)
    {
    }

    public override bool IsEligibleToBePerformedBy(Interactor interactor)
    {
        return true;
    }
}