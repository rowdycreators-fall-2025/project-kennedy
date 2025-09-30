using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionBehavior
{
    public InputAction input;
    public string description;
    public Func<bool> isPossible;

    public InteractionBehavior(InputAction input, string description, Func<bool> isPossible)
    {
        this.input = input;
        this.description = description;
        this.isPossible = isPossible;
    }

    public string getBindingDisplayStr()
    {
        return input.GetBindingDisplayString();
    }
}