using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    
    [SerializeField] private string itemActionText;
    [SerializeField] private GameObject highlightObject;
    [SerializeField] private Interaction interaction;

    private bool isMouseOver;


    private void OnMouseOver()
    {
        if (!isMouseOver)
        {
            if (interaction.CanInteract)
            {
                highlightObject.SetActive(true);
                LabUIManager.Instance.SetActionText(itemActionText);  
            }
            else
            {
                highlightObject.SetActive(false);
                LabUIManager.Instance.ClearActionText();
            }
            
        }

        isMouseOver = true;
    }

    private void OnMouseExit()
    {
        highlightObject.SetActive(false);
        LabUIManager.Instance.ClearActionText();
        isMouseOver = false;
    }


    private void OnMouseDown()
    {
        if (interaction.CanInteract)
        {
            interaction.Interact();
        }
    }
}