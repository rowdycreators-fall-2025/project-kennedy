using System;
using UnityEngine;

public class TakeItemAction : Action
{
    protected override string input => "Interaction";
    protected override string description => "Take";
    protected override bool isInstantAction => true;

    public TakeItemAction(Interactable interactableTarget) : base(interactableTarget)
    {
    }

    public override bool IsEligibleToBePerformedBy(Interactor interactor)
    {
        return true;
    }
}