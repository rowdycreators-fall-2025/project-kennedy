using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Grabbable : Interactable
{
    GameObject grabbedBy;

    void Start()
    {
        base.Start();

        possibleActions.Add(new InteractionBehavior(inputActions.FindAction("Interaction"), "Grab", CanGrab));
        possibleActions.Add(new InteractionBehavior(inputActions.FindAction("Interaction"), "Let Go", CanLetGo));
    }

    void OnEnable()
    {
        base.OnEnable();

        inputActions.Interact.Interaction.performed += OnInteraction; // Subscribes to the 'Interaction' action's 'performed' event
    }

    void OnDisable()
    {
        base.OnDisable();

        inputActions.Interact.Interaction.performed -= OnInteraction; // unsub
    }

    bool CanGrab()
    {
        return IsHovered(); // can't pick up an object that isn't hovered
    }
    void Grab()
    {
        grabbedBy = whoIsHovering;
        gameObject.transform.SetParent(grabbedBy.transform, true); // worldPositionStays = true
        Debug.Log("Grabbable: grabbed object");
    }
    bool CanLetGo()
    {
        return grabbedBy != null;
    }
    void LetGo()
    {
        gameObject.transform.SetParent(null, true); // worldPositionStays = true
        grabbedBy = null;
        Debug.Log("Grabbable: let go of object");
    }

    void OnInteraction(InputAction.CallbackContext ctx)
    {
        // player grabs item or releases item
        if (CanLetGo())
        {
            // player always lets go of existing item when grab/release key is pressed
            LetGo();
            return;
        }
        if (CanGrab())
        {
            Grab();
            return;
        }

    }
}
