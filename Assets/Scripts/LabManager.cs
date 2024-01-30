using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabManager : MonoBehaviour
{
    public static LabManager Instance { get; private set; }
    
    public event EventHandler OnPhenolphthaleinDropAdded;
    public event EventHandler OnWaterPoured;
    public event EventHandler OnHCIAdded;
    public event EventHandler OnHCIDropAdded;
    public event EventHandler OnMagnetAdded;
    
    [Header("Water States")] 
    private ContainerState waterContainerState;
    private WaterState waterState;
    private int numberOfPhenolphthaleinDrops;

    [Header("Solution States")]
    private ContainerState solutionContainerState;
    
    private void Awake()
    {
        Instance = this;
        
        Init();
    }



    private void Init()
    {
        numberOfPhenolphthaleinDrops = 0;
        waterState = WaterState.Unchanged;
        waterContainerState = ContainerState.Filled;

        solutionContainerState = ContainerState.Empty;
    }
    
    public void AddPhenolphthaleinDrop()
    {
        if (numberOfPhenolphthaleinDrops == 3)
            return;
        
        numberOfPhenolphthaleinDrops++;
        SetWaterState();
        OnPhenolphthaleinDropAdded?.Invoke(this,EventArgs.Empty);
    }

    public void PourWater()
    {
        if (waterContainerState == ContainerState.Empty)
            return;

        waterContainerState = ContainerState.Empty;
        OnWaterPoured?.Invoke(this,EventArgs.Empty);
    }


    public void SetWaterState()
    {
        if (numberOfPhenolphthaleinDrops == 1)
            waterState = WaterState.Unchanged;
        else if (numberOfPhenolphthaleinDrops == 2)
            waterState = WaterState.MidChanging;
        else
            waterState = WaterState.Changed;
    }

    public void AddHCI()
    {
        OnHCIAdded?.Invoke(this,EventArgs.Empty);
    }

    public void AddHCIDrop()
    {
        OnHCIDropAdded?.Invoke(this,EventArgs.Empty);
    }

    public void AddMagnet()
    {
        OnMagnetAdded?.Invoke(this,EventArgs.Empty);
    }
    
    

    public ContainerState WaterContainerState
    {
        get => waterContainerState;
        set => waterContainerState = value;
    }

    public WaterState WaterState => waterState;

    public int NumberOfPhenolphthaleinDrops => numberOfPhenolphthaleinDrops;


    public ContainerState SolutionContainerState
    {
        get => solutionContainerState;
        set => solutionContainerState = value;
    }
}