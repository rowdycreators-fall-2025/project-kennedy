using UnityEngine;
using System;
using System.Collections.Generic;

public class HUDController : MonoBehaviour
{
    [SerializeField] private HUDInteractionChoices HUDElementInteractionChoices;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnUpdatePlayerInteractionChoices()
    {
        // pass to HUDInteractionChoices
        HUDElementInteractionChoices.OnUpdateActionsList();
    }
}
