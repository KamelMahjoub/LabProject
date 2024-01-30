using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LabUIManager : MonoBehaviour
{
    public static LabUIManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI actionText;


    private void Awake()
    {
        Instance = this;
        ClearActionText();
    }


    public void SetActionText(string text)
    {
        actionText.text = text;
    }

    public void ClearActionText()
    {
        actionText.text = "";
    }
    
    
    
}
