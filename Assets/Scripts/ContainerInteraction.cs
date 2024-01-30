using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ContainerInteraction : Interaction
{
    [SerializeField] private GameObject fillObject;
    
    [SerializeField] private Material waterMaterial;
    [SerializeField] private Material midChangeWaterMaterial; 
    [SerializeField] private Material ChangedWaterMaterial;
    
    private Animator animator;
    
    public override bool CanInteract { get; set; }


    private void Start()
    {
        animator = GetComponent<Animator>();
        LabManager.Instance.OnWaterPoured += LabManager_OnWaterPoured;
        CanInteract = false;
    }

    private void LabManager_OnWaterPoured(object sender, EventArgs e)
    {
        StartCoroutine(PourWater());
        animator.SetTrigger("FillContainer");
        ChangeWaterColor();
        fillObject.SetActive(true);
        LabManager.Instance.SolutionContainerState = ContainerState.Filled;
        CanInteract = true;
    }

    public override void Interact()
    {
        animator.SetTrigger("MoveContainer");
        CanInteract = false;
    }
    
    private void ChangeWaterColor()
    {
        MeshRenderer renderer = fillObject.GetComponent<MeshRenderer>();
        
        switch (LabManager.Instance.WaterState)
        {
            case WaterState.Unchanged:
                renderer.material = waterMaterial;
                break;
            case WaterState.MidChanging:
                renderer.material = midChangeWaterMaterial;
                break;
            case WaterState.Changed:
                renderer.material = ChangedWaterMaterial;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    private IEnumerator PourWater()
    {
        yield return new WaitForSeconds(1.5f);
        
    }
    
}
