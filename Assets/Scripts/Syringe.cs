using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Syringe : MonoBehaviour
{

    private Animator animator;

    [SerializeField] private GameObject fillObject;


    private void Start()
    {
        LabManager.Instance.OnHCIAdded += LabManager_OnHCIAdded;
        LabManager.Instance.OnHCIDropAdded += LabManager_OnHCIDropAdded;
        
        animator = GetComponent<Animator>();
    }

    private void LabManager_OnHCIDropAdded(object sender, EventArgs e)
    {
        animator.SetTrigger("AddHCIDrop");
    }

    private void LabManager_OnHCIAdded(object sender, EventArgs e)
    {
        fillObject.SetActive(true);
    }
}
