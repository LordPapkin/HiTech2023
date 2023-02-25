using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TierButton : MonoBehaviour
{
    [SerializeField] private ButtonUnitSpawn[] tierUnitsButtons;
    [SerializeField] private ResourceCost unlockCost;

    private Button thisButton;
    private bool isUnlocked = false;
    private void OnEnable()
    {
        GameEvents.OnResourceAmountChange += CheckCost;
    }

    private void Awake()
    {
        thisButton = GetComponent<Button>();
    }

    private void Start()
    {
        CheckCost();
    }

    private void OnDisable()
    {
        GameEvents.OnResourceAmountChange -= CheckCost;
    }

    public void UnlockTierUnits()
    {
        if(isUnlocked)
            return;
        if(!ResourceManager.Instance.CanAfford(unlockCost))
            return;

        ResourceManager.Instance.SpendResources(unlockCost);
        foreach (var button in tierUnitsButtons)
        {
            button.Unlock();
        }

        isUnlocked = true;
    }
    
    private void CheckCost()
    {
        thisButton.interactable = ResourceManager.Instance.CanAfford(unlockCost);
    }
}
