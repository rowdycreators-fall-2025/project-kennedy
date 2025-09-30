using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine.UI; // Required for UI elements

// a UI component

public class HUDInteractionChoices : MonoBehaviour
{
    [SerializeField] private PlayerInteractor playerInteractor;
    [SerializeField] private Text textComponent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInteractor = GameObject.FindWithTag("MainCamera").GetComponent<PlayerInteractor>();
        textComponent = gameObject.GetComponent<Text>();
        textComponent.text = "";
    }

    void Update()
    {
    }

    void LateUpdate()
    {
    }

    public void OnUpdateActionsList()
    {
        // Debug.Log("HUDInteractionChoices received event : player interaction choices changed");

        List<Action> actionsPlayerCanPerform = playerInteractor.choices;

        StringBuilder sb = new StringBuilder();
        // displays allowed actions and their mouse/keybinds
        foreach (Action choice in actionsPlayerCanPerform)
        {
            sb.AppendLine($"{choice.GetStaticDescription()} [ {playerInteractor.GetBindingDisplayStr(choice)} ]");
        }

        textComponent.text = sb.ToString();
    }
}
