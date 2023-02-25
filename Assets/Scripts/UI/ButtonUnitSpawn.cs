using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUnitSpawn : MonoBehaviour
{
    [SerializeField] private UnitSO unitToSpawn;
    private UnitSpawner unitSpawner;
    private Button thisButton;

    private void Awake()
    {
        thisButton = GetComponent<Button>();
    }

    private void Start()
    {
        unitSpawner = UnitSpawner.Instance;
        ValidateUnitSpawner();
    }

    public void SpawnUnit()
    {
        ValidateUnitSpawner();
        if (unitSpawner.SpawnUnit(unitToSpawn))
        {
            thisButton.interactable = false;
            StartCoroutine(UnitCooldown());
        }
    }
    
    private void ValidateUnitSpawner()
    {
        if (unitSpawner == null)
        {
            Debug.LogError("Brak Unit Spawnera na scenie");
        }
    }

    private IEnumerator UnitCooldown()
    {
        yield return new WaitForSeconds(unitToSpawn.UnitCooldown);
        thisButton.interactable = true;
    }

}
