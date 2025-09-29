using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Grabbable : Interactable
{
    GameObject grabbedBy;
    Dictionary<string, int> actions = new Dictionary<string, int>();

    void Start()
    {
        // actions.Add("", 0);
    }

    void OnEnable()
    {
        base.OnEnable();

        inputActions.Interact.PickUp.performed += OnPickUp; // Subscribes to the 'PickUp' action's 'performed' event
    }

    void OnDisable()
    {
        base.OnDisable();

        inputActions.Interact.PickUp.performed -= OnPickUp; // unsub
    }

    void OnPickUp(InputAction.CallbackContext ctx)
    {
        // player grabs item or releases item
        if (grabbedBy)
        {
            // player always lets go of existing item when grab/release key is pressed
            gameObject.transform.SetParent(null, true);
            grabbedBy = null;
            return;
        }
        if (!isHovered)
        {
            return; // can't pick up an object that isn't hovered
        }
        Debug.Log("pickup performed!");
        grabbedBy = player;
        gameObject.transform.SetParent(grabbedBy.transform, true);
    }
}
