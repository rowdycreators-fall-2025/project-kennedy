using System;
using System.Linq;
public class ReleaseAction : Action
{
    protected override Type[] stops => new Type[] { typeof(GrabAction) };
    protected override string input => "Interaction";
    protected override string description => "Let Go";
    protected override bool isInstantAction => true;

    public ReleaseAction(Interactable interactableTarget) : base(interactableTarget)
    {
    }

    public override bool IsEligibleToBePerformedBy(Interactor interactor)
    {
        bool isInteractorGrabbingThis = interactor.ongoingActions.Any(ongoingAct => ongoingAct.GetType() == typeof(GrabAction) && ongoingAct.interactableTarget == interactableTarget);
        return isInteractorGrabbingThis;
    }
}