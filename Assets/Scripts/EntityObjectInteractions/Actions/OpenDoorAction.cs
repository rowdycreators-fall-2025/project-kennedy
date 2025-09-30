using System;
using UnityEngine;
public class OpenDoorAction : Action
{
    protected override string input => "Interaction";
    protected override string description => "Open";
    protected override bool isInstantAction => true;

    public OpenDoorAction(Interactable interactableTarget) : base(interactableTarget)
    {
    }

    public override bool IsEligibleToBePerformedBy(Interactor interactor)
    {
        return true;
    }
}