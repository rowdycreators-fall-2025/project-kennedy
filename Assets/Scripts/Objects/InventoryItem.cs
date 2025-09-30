using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class InventoryItem : Interactable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();

        possibleActions.Add(new InteractionBehavior(inputActions.FindAction("Interaction"), "Take", CanTake));
    }

    bool CanTake()
    {
        return false;
    }
    void Take()
    {
        // add item to player item bar, replaces existing item in slot if occupied
    }

    void OnInteraction(InputAction.CallbackContext ctx)
    {
    }
}
