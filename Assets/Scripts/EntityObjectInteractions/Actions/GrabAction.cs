using System.Linq;
public class GrabAction : Action
{
    protected override string input => "Interaction";
    protected override string description => "Grab";
    protected override bool isInstantAction => false;

    public GrabAction(Interactable interactableTarget) : base(interactableTarget)
    {
    }

    protected override void Start(Interactor interactor)
    {
        base.Start(interactor);
        ((Grabbable)interactableTarget).PerformGrab(interactor);
        interactor.LockFocus();
    }
    protected override void Stop(Interactor interactor)
    {
        base.Stop(interactor);
        ((Grabbable)interactableTarget).PerformRelease(interactor);
        interactor.UnlockFocus();
    }

    public override bool IsEligibleToBePerformedBy(Interactor interactor)
    {
        bool isInteractorAlreadyGrabbingSomething = interactor.ongoingActions.Any(ongoingAct => ongoingAct.GetType() == typeof(GrabAction));
        return !isInteractorAlreadyGrabbingSomething;
    }
}