using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Collections.Generic;

public class InventoryItem : Interactable
{
    protected override Type[] possibleActionTypes => new Type[] {
        typeof(TakeItemAction)
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    public void PerformTake()
    {
        // add item to player item bar, replaces existing item in slot if occupied
    }
}
