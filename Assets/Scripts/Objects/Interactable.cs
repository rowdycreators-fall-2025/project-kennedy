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
    // style
    private float OUTLINE_WIDTH = 4.0f;
    private Color OUTLINE_COLOR = Color.cyan;

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

    private void DisplayActions()
    {
        // shows available actions on the screen
    }

    private void HideActionsDisplay()
    {

    }

    void LateUpdate()
    {
        if (!IsHovered())
        {
            HideActionsDisplay();
            SetVisualHighlight(false);
        }
        else
        {
            DisplayActions();
            SetVisualHighlight(true);
        }
    }

    private void SetVisualHighlight(bool enable)
    {
        Outline outlineComponent;
        if ((outlineComponent = gameObject.GetComponent<Outline>()) != null && !enable)
        {
            Destroy(outlineComponent);
            return;
        }
        if (outlineComponent == null && enable)
        {
            outlineComponent = gameObject.AddComponent<Outline>();
            outlineComponent.enabled = true;
            outlineComponent.OutlineWidth = OUTLINE_WIDTH;
            outlineComponent.OutlineColor = OUTLINE_COLOR;
        }
    }

    // called when the player hovers over the Interactible
    public void OnHover(GameObject hoverer)
    {
        whoIsHovering = hoverer;

        if (hoverer.tag == "Player") // if the hoverer is the player
        {
            // shows available actions on the screen if the hoverer is the player
            DisplayActions();
        }
    }
}
