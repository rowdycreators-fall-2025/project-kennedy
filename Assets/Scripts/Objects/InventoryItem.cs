using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class InventoryItem : Interactable
{

    Dictionary<string, int> actions = new Dictionary<string, int>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    void OnPickUp(InputAction.CallbackContext ctx)
    {
        // add to player inventory
    }
}
