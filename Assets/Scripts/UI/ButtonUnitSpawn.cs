using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUnitSpawn : MonoBehaviour
{
    [SerializeField] private UnitSO unitToSpawn;
    [SerializeField] private bool isLocked;
    
    private UnitSpawner unitSpawner;
    private Button thisButton;

    private bool isOnCooldown = false;
    //domyśle zaczynamy bez surowców
    private bool isToExpensive = true;

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
        unitSpawner = UnitSpawner.Instance;
        ValidateUnitSpawner();
        CheckIfAvailable();
    }

    private void OnDisable()
    {
        GameEvents.OnResourceAmountChange -= CheckCost;
    }

    public void SpawnUnit()
    {
        VaildateUnit();
        ValidateUnitSpawner();
        if (unitSpawner.SpawnUnit(unitToSpawn))
        {
            isOnCooldown = true;
            CheckIfAvailable();
            StartCoroutine(UnitCooldown());
        }
    }

    public void Unlock()
    {
        isLocked = false;
        CheckIfAvailable();
    }
    
    private void CheckIfAvailable()
    {
        if (isLocked)
        { 
            thisButton.interactable = false;
            return;
        }
        
        if (isOnCooldown)
        {
            thisButton.interactable = false;
            return;
        }
        
        if (isToExpensive)
        {
            thisButton.interactable = false;
            return;
        }
            

        thisButton.interactable = true;
    }
    
    private IEnumerator UnitCooldown()
    {
        yield return new WaitForSeconds(unitToSpawn.UnitCooldown);
        isOnCooldown = false;
        CheckIfAvailable();
    }

    private void CheckCost()
    {
        isToExpensive = !ResourceManager.Instance.CanAfford(unitToSpawn.UnitCost);
        CheckIfAvailable();
    }
    
    private void ValidateUnitSpawner()
    {
        if (unitSpawner == null)
        {
            Debug.LogError("Brak Unit Spawnera na scenie");
        }
    }

    private void VaildateUnit()
    {
        if (unitToSpawn == null)
        {
            Debug.LogError("Brak przypisanego Unita do buttona");
        }
    }

}
