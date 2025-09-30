using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class OpenClosableDoor : Interactable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();

        possibleActions.Add(new InteractionBehavior(inputActions.FindAction("Interaction"), "Open", CanOpen));
        possibleActions.Add(new InteractionBehavior(inputActions.FindAction("Interaction"), "Close", CanClose));
    }

    bool CanOpen()
    {
        return false;
    }
    void Open()
    {
    }

    bool CanClose()
    {
        return false;
    }
    void Close()
    {
    }

    void OnInteraction(InputAction.CallbackContext ctx)
    {
    }
}
