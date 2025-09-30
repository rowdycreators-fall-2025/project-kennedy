using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Collections.Generic;
using UnityEngine.Events;

/*
Interactable = a GameObject the player can interact with by pressing {default keybind: E}
Subclasses:
    Grabbable = something the interactor can hold and let go of (example: Companion Cube in Portal)
    InventoryItem = a floating billboard of an item the interactor can take up into their inventory and use (example: Wooden Pickaxe in Minecraft)
    OpenClosableDoor = something (usually a door) that the player can open and close
    ItemDispenser = something that spits out InventoryItems when the interactor interacts with it (example: Chest in Fortnite)
    LockedItemDispenser = a subclass of ItemDispenser that requires the interactor to have a key to trigger it
*/

public class Interactable : MonoBehaviour
{
    protected virtual Type[] possibleActionTypes => Array.Empty<Type>();

    // focus style
    [SerializeField] private readonly static float PLAYER_FOCUS_OUTLINE_WIDTH = 4.0f;
    [SerializeField] private readonly static Color PLAYER_FOCUS_OUTLINE_COLOR = Color.cyan;

    private Outline outlineComponent;

    protected virtual void Start()
    {

    }

    public Dictionary<Type, Action> GetCurrentActionChoices(Interactor interactor)
    {
        Dictionary<Type, Action> currentChoicesForInteractor = new Dictionary<Type, Action>();
        foreach (Type typeAction in possibleActionTypes)
        {
            // Debug.Log("GetCurrentActionChoices loop iter");
            Action a = (Action)typeAction.GetConstructor(new Type[] { typeof(Interactable) }).Invoke(new object[] { (Interactable)this });
            if (a.IsEligibleToBePerformedBy(interactor))
            {
                currentChoicesForInteractor.Add(typeAction, a);
            }
        }
        // Debug.Log(currentChoicesForInteractor.ToString());
        return currentChoicesForInteractor;
    }

    public void SetVisualHighlight(bool enable)
    {
        if (enable)
        {
            if (outlineComponent == null)
            {
                outlineComponent = gameObject.AddComponent<Outline>();
            }
            outlineComponent.enabled = true;
            outlineComponent.OutlineWidth = PLAYER_FOCUS_OUTLINE_WIDTH;
            outlineComponent.OutlineColor = PLAYER_FOCUS_OUTLINE_COLOR;
        }
        if (!enable && outlineComponent != null)
        {
            outlineComponent.enabled = false;
        }
    }
}
