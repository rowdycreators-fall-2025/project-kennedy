using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Collections.Generic;

public class Grabbable : Interactable
{
    protected override Type[] possibleActionTypes => new Type[] {
        typeof(GrabAction),
        typeof(ReleaseAction),
        typeof(ThrowAction),
    };

    protected override void Start()
    {
        base.Start();
    }

    //

    public void PerformGrab(Interactor grabber)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        gameObject.transform.SetParent(grabber.gameObject.transform, true); // worldPositionStays = true
        Debug.Log("Grabbable: grabbed object");
    }
    public void PerformRelease(Interactor grabber)
    {
        GetComponent<Rigidbody>().isKinematic = false;
        gameObject.transform.SetParent(null, true); // worldPositionStays = true
        Debug.Log("Grabbable: let go of object");
    }
    public void PerformThrow(Interactor thrower)
    {
        float THROW_SPEED = 50.0f;
        float THROW_LIFT = 1.0f;
        gameObject.GetComponent<Rigidbody>().linearVelocity = THROW_SPEED * thrower.gameObject.transform.forward + new Vector3(0.0f, 0.0f, THROW_LIFT);
    }
}
