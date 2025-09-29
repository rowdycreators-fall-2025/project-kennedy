using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Interactable : MonoBehaviour
{
    public GameObject player;
    protected PlayerInputActions inputActions;
    protected Dictionary<string, int> actions; // keys and actions to display on hover

    protected bool isHovered = false;

    void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    protected void OnEnable()
    {
        inputActions.Enable(); // Enables all action maps in the asset
        inputActions.Interact.Enable();
    }

    protected void OnDisable()
    {
        inputActions.Disable(); // Disables all action maps
    }

    void Update()
    {
        isHovered = false;
    }

    // called when the player hovers over the Interactible
    public void OnHover()
    {
        isHovered = true;

        // shows available actions on the screen
    }
}
