using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Collections.Generic;

public class OpenClosableDoor : Interactable

{
    protected override Type[] possibleActionTypes => new Type[] {
        typeof(OpenDoorAction),
        typeof(CloseDoorAction),
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    public void PerformOpen()
    {
    }
    public void PerformClose()
    {
    }
}
