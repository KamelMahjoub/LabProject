using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HCIInteraction : Interaction
{
    public override bool CanInteract { get; set; }
    
    private Animator animator;

    private void Start()
    {
        CanInteract = true;
        animator = GetComponent<Animator>();
    }


    public override void Interact()
    {
        CanInteract = false;
        PlayAnimation();
        StartCoroutine(AddDrop());
    }
    
    private void PlayAnimation()
    {
        animator.SetTrigger("AddHCI");
    }

    private IEnumerator AddDrop()
    {
        yield return new WaitForSeconds(2f);
       LabManager.Instance.AddHCI();
        CanInteract = true;
    }
}
