using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

/*
Interactable = a GameObject the player can interact with by pressing {default keybind: E}
Subclasses:
    Grabbable = something the player can hold and let go of (example: Companion Cube in Portal)
    InventoryItem = a floating billboard of an item the player can take up into their inventory and use (example: Wooden Pickaxe in Minecraft)
    OpenClosableDoor = something (usually a door) that the player can open and close
    ItemDispenser = something that spits out InventoryItems when the player interacts with it (example: Chest in Fortnite)

*/

public class Interactable : MonoBehaviour
{
    protected PlayerInputActions inputActions;
    protected List<InteractionBehavior> possibleActions; // keys and actions to display on hover

    protected GameObject whoIsHovering;

    protected bool IsHovered()
    {
        return whoIsHovering != null;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void Start()
    {
        possibleActions = new List<InteractionBehavior>();
    }

    void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    protected void OnEnable()
    {
        inputActions.Enable();
        inputActions.Interact.Enable();
    }

    protected void OnDisable()
    {
        inputActions.Interact.Disable();
        inputActions.Disable();
    }

    void Update()
    {
        whoIsHovering = null;
        // AFTER this runs, the PlayerCameraLook script calls OnHover, setting 1 object’s isHovered flag to true
    }

    // called when the player hovers over the Interactible
    public void OnHover(GameObject hoverer)
    {
        whoIsHovering = hoverer;

        if (hoverer.tag == "Player")
        {
            // shows available actions on the screen if the hoverer is the player

        }
    }
}
