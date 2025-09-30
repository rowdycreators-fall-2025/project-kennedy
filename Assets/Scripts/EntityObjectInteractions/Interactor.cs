using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;
using Unity.VisualScripting;

// Interactor = an entity that can interact with Interactables

public class Interactor : MonoBehaviour
{
    public List<Action> choices { get; protected set; } // what the interactor can do
    public List<Action> ongoingActions { get; protected set; } // what the interactor is doing

    [SerializeField] protected readonly float maxFocusDistance = 2.0f;

    [SerializeField] protected Interactable interactableInFocus;
    [SerializeField] private bool lockFocus = false;

    protected virtual void Start()
    {
        choices = new List<Action>();
        ongoingActions = new List<Action>();
    }

    protected virtual void Update()
    {
        if (!lockFocus)
        {
            // raycasts for interaction
            Look();
        }

        if (interactableInFocus != null)
        {
            Dictionary<Type, Action> interactibleActionChoices = interactableInFocus.GetCurrentActionChoices(this);
            AddChoices(interactibleActionChoices.Values.ToList());

            // Debug.Log(choices.ToCommaSeparatedString());
        }
    }

    void LateUpdate()
    {
        RemoveIneligibleActionChoices();
    }

    //

    private void RemoveIneligibleActionChoices()
    {
        choices.RemoveAll(choice => !choice.IsEligibleToBePerformedBy(this)); // removes ineligible action choices
    }

    public void AddChoice(Action a, bool doFireChoicesChangedEvent = true)
    {
        // Debug.Log("AddChoice : " + a.GetStaticDescription());
        if (choices.Any(choice => choice.Equals(a)))
        {
            return;
        }
        choices.Add(a);
        if (doFireChoicesChangedEvent) OnChoicesChanged();
    }
    public void AddChoices(List<Action> choices)
    {
        foreach (var a in choices)
        {
            AddChoice(a, false);
        }
        OnChoicesChanged();
    }
    private void RemoveChoice(Action a)
    {
        choices.RemoveAll(choice => a.Equals(ongoingActions));
        OnChoicesChanged();
    }
    private void ClearChoices()
    {
        choices.Clear();
        OnChoicesChanged();
    }

    public void AddOngoingAction(Action a)
    {
        ongoingActions.Add(a);
        OnOngoingActionsChanged();
    }
    public void RemoveOngoingAction(Action a)
    {
        // Debug.Log("Interactor : RemoveOngoingAction");
        ongoingActions.RemoveAll(ongoingAction => a.Equals(ongoingAction));
        OnOngoingActionsChanged();
    }

    protected virtual void OnChoicesChanged()
    {

    }

    protected virtual void OnOngoingActionsChanged()
    {
        RemoveIneligibleActionChoices();
    }

    //

    public void LockFocus()
    {
        lockFocus = true;
    }
    public void UnlockFocus()
    {
        lockFocus = false;
    }

    //

    protected virtual Ray CreateRayToCast()
    {
        return new Ray(gameObject.transform.position, gameObject.transform.forward);
    }

    protected virtual void FocusInteractable(Interactable i)
    {
        if (i != interactableInFocus)
        {
            ClearChoices();
            interactableInFocus = i;
        }
    }

    protected RaycastHit PerformRaycast(Ray ray)
    {
        bool foundInteractable = false;
        // Using the ray for a RaycastHit
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxFocusDistance))
        {
            // If the ray hits something, you can access 'hit.collider.gameObject', 'hit.point', etc.
            GameObject hitObject = hit.collider.gameObject;

            Interactable interactableInterface;
            if (interactableInterface = hitObject.GetComponent<Interactable>()) // checks if the hit gameObject is interactable
            {
                foundInteractable = true;
                FocusInteractable(interactableInterface);
            }
        }
        if (!foundInteractable)
        {
            FocusInteractable(null);
            // Debug.Log("should have no focus");
        }
        return hit;
    }

    void Look()
    {
        // Debug.Log("Interactor : Look");
        PerformRaycast(CreateRayToCast());
    }
}