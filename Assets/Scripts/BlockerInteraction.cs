using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerInteraction : Interaction
{
    public override bool CanInteract { get; set; }

    private void Start()
    {
        CanInteract = true;
    }

    public override void Interact()
    {
        CanInteract = false;
        LabManager.Instance.AddHCIDrop();
        CanInteract = true;
    }
}
