using System;
using System.Linq;
public class ThrowAction : Action
{
    protected override Type[] stops => new Type[] { typeof(GrabAction) };
    protected override string input => "InteractionAlt";
    protected override string description => "Throw";
    protected override bool isInstantAction => true;

    public ThrowAction(Interactable interactableTarget) : base(interactableTarget)
    {
    }

    protected override void Start(Interactor interactor)
    {
        base.Start(interactor);
        ((Grabbable)interactableTarget).PerformThrow(interactor);
    }

    public override bool IsEligibleToBePerformedBy(Interactor interactor)
    {
        return true;
    }
}