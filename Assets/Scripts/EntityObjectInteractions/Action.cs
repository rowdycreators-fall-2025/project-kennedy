using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Action
{
    protected virtual string input => null;
    protected virtual string description => null;
    protected virtual bool isInstantAction => false; // if true Stop() runs immediately after Start() in the same update cycle

    protected virtual Type[] stops => Array.Empty<Type>(); // action types this action stops

    public Interactable interactableTarget { get; private set; }
    public bool didStart = false;
    public bool didStop = false;

    public Action(Interactable interactableTarget)
    {
        this.interactableTarget = interactableTarget;
    }

    public virtual bool IsEligibleToBePerformedBy(Interactor interactor)
    {
        return true;
    }

    private void StopComplimentary(Interactor interactor)
    {
        Queue<System.Action> funcQueue = new Queue<System.Action>();
        foreach (Type actionType in stops)
        {
            foreach (Action ongoingAct in interactor.ongoingActions)
            {
                if (ongoingAct.GetType() == actionType && ongoingAct.interactableTarget == interactableTarget)
                {
                    funcQueue.Enqueue(() => ongoingAct.Stop(interactor));
                }
            }
        }
        while (funcQueue.Count > 0)
        {
            System.Action currentAction = funcQueue.Dequeue();
            currentAction.Invoke();
        }
    }
    protected virtual void Start(Interactor interactor)
    {
        interactor.AddOngoingAction(this);
        didStart = true;
    }
    protected virtual void Stop(Interactor interactor)
    {
        interactor.RemoveOngoingAction(this);
        didStop = true;
    }

    public void Do(Interactor interactor)
    {
        Debug.Log("Do Action : " + this.GetType().ToString());

        StopComplimentary(interactor);
        Start(interactor);
        if (isInstantAction)
        {
            Stop(interactor);
        }
    }

    //

    public string GetInputName()
    {
        return input;
    }

    public string GetStaticDescription()
    {
        return description;
    }

    public override bool Equals(object obj)
    {
        if (obj is Action)
        {
            return ((Action)obj).interactableTarget == this.interactableTarget && obj.GetType() == this.GetType();
        }
        return false;
    }

    public override int GetHashCode() => base.GetHashCode();
}