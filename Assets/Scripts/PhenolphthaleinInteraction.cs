using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhenolphthaleinInteraction : Interaction
{
    private Animator animator;
    
    public override bool CanInteract { get; set; }
   

    private void Start()
    {
        animator = GetComponent<Animator>();
        CanInteract = true;
    }

  

    public override void Interact()
    {

        if (LabManager.Instance.NumberOfPhenolphthaleinDrops >= 3)
            return;

        CanInteract = false;
        PlayAnimation();
        StartCoroutine(AddDrop());
    }


    private void PlayAnimation()
    {
        animator.SetTrigger("AddDrop");
    }

    private IEnumerator AddDrop()
    {
        yield return new WaitForSeconds(2f);
        LabManager.Instance.AddPhenolphthaleinDrop();
        CanInteract = true;
    }
    
}