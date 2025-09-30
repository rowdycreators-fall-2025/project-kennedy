using System;
using UnityEngine;
public class DispenseLootAction : Action
{
    protected override string input => "Interaction";
    protected override string description => "Interact";
    protected override bool isInstantAction => true;

    public DispenseLootAction(Interactable interactableTarget) : base(interactableTarget)
    {
    }

    public override bool IsEligibleToBePerformedBy(Interactor interactor)
    {
        return true;
    }
}