using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetInteraction : Interaction
{
    public override bool CanInteract { get; set; }
    
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        CanInteract = true;
    }

    public override void Interact()
    {
       animator.SetTrigger("MoveMagnet");
       LabManager.Instance.AddMagnet();
    }
}


