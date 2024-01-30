using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class WaterInteraction : Interaction
{
    [SerializeField] private GameObject fillObject;

    [SerializeField] private Material waterMaterial;
    [SerializeField] private Material midChangeWaterMaterial;
    [SerializeField] private Material ChangedWaterMaterial;

    public override bool CanInteract { get; set; }
    
    private Animator animator;


    private void Start()
    {
        
        animator = GetComponent<Animator>();
        
        LabManager.Instance.OnPhenolphthaleinDropAdded += LabManager_OnPhenolphthaleinDropAdded;
        LabManager.Instance.OnWaterPoured += LabManager_OnWaterPoured;

        CanInteract = true;
    }


    private void Update()
    {
        if(LabManager.Instance.WaterContainerState == ContainerState.Empty)
            fillObject.SetActive(false);
    }

    private void LabManager_OnPhenolphthaleinDropAdded(object sender, EventArgs e)
    {
        ChangeWaterColor();
    }

    private void LabManager_OnWaterPoured(object sender, EventArgs e)
    {
        fillObject.SetActive(false);
    }

   

    public override void Interact()
    {
        if (LabManager.Instance.WaterContainerState == ContainerState.Empty)
            return;

        CanInteract = false;
        PlayAnimation();
        StartCoroutine(PourWater());
        LabManager.Instance.PourWater();
        LabManager.Instance.WaterContainerState = ContainerState.Empty;
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


    private void PlayAnimation()
    {
        animator.SetTrigger("PourWater");
    }

    private IEnumerator PourWater()
    {
        yield return new WaitForSeconds(1.5f);
        LabManager.Instance.PourWater();
        CanInteract = false;
    }
}