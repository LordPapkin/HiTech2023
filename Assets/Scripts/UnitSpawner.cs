using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public static UnitSpawner Instance => instance;
    private static UnitSpawner instance;

    //for test
    [SerializeField] private UnitSO testUnit;

    private void Update()
    {
        //just for test
        if (Input.GetKeyDown(KeyCode.W))
        {
            SpawnUnit(testUnit);
        }
    }

    public void SpawnUnit(UnitSO unitType)
    {
        bool isSpawned = ResourceManager.Instance.SpendResources(unitType.UnitResource, unitType.UnitCost);
        if (!isSpawned)
        {
            Debug.LogWarning("Brak zasobów");
            return;
        }
            
        Instantiate(unitType.UnitPrefab, transform.position, Quaternion.identity, transform);
    }
    
}
