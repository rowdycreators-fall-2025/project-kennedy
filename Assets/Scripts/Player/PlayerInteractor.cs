using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine.Events;

public class PlayerInteractor : Interactor
{
    protected PlayerInputActions playerInputActions;

    [SerializeField] private UnityEvent unityEventToUpdateHUDInteractionChoices;
    [SerializeField] private HUDController _HUDController;

    void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    protected override void Start()
    {
        base.Start();
        _HUDController = GameObject.FindWithTag("UI_HUD").GetComponent<HUDController>();
        unityEventToUpdateHUDInteractionChoices = new UnityEvent();
        unityEventToUpdateHUDInteractionChoices.AddListener(_HUDController.OnUpdatePlayerInteractionChoices);
    }

    protected override void Update()
    {
        base.Update();
    }

    protected void OnEnable()
    {
        Debug.Log("OnEnable");
        playerInputActions.Enable();
        playerInputActions.Interact.Enable();

        playerInputActions.Interact.Interaction.performed += OnInputInteraction; // Subscribes to the 'Interaction' action's 'performed' event
        playerInputActions.Interact.InteractionAlt.performed += OnInputInteractionAlt; // Subscribes to the 'InteractionAlt' action's 'performed' event
    }

    protected void OnDisable()
    {
        playerInputActions.Interact.Disable();
        playerInputActions.Disable();

        // unsubs
        playerInputActions.Interact.Interaction.performed -= OnInputInteraction;
        playerInputActions.Interact.InteractionAlt.performed -= OnInputInteractionAlt;
    }

    protected override void OnChoicesChanged()
    {
        base.OnChoicesChanged();
        // sends Unity event specific to player's interaction choices
        unityEventToUpdateHUDInteractionChoices.Invoke();
    }

    protected override Ray CreateRayToCast()
    {
        // Calculates the center of the screen in pixel coordinates
        // Screen.width and Screen.height give the current screen resolution
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);

        // raycasts forward at screen center
        return Camera.main.ScreenPointToRay(screenCenter);
    }

    protected override void FocusInteractable(Interactable i)
    {
        if (i == interactableInFocus)
        {
            return; // no change
        }
        if (interactableInFocus != null)
        {
            interactableInFocus.SetVisualHighlight(false); // disables outline effect on previous focused obj
        }
        base.FocusInteractable(i);
        if (interactableInFocus != null)
        {
            interactableInFocus.SetVisualHighlight(true);
        }
    }

    //

    public string GetBindingDisplayStr(Action a)
    {
        return playerInputActions.FindAction(a.GetInputName()).GetBindingDisplayString();
    }

    void PerformInteraction(InputAction input)
    {
        foreach (Action choice in choices)
        {
            if (choice.GetInputName() == input.name)
            {
                choice.Do(this);
                break;
            }
        }
    }

    void OnInputInteraction(InputAction.CallbackContext ctx)
    {
        Debug.Log("pressed E");
        PerformInteraction(playerInputActions.FindAction("Interaction"));
    }

    void OnInputInteractionAlt(InputAction.CallbackContext ctx)
    {
        Debug.Log("pressed C");
        PerformInteraction(playerInputActions.FindAction("InteractionAlt"));
    }
}