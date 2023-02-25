using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public static UnitSpawner Instance => instance;
    private static UnitSpawner instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    public bool SpawnUnit(UnitSO unitType)
    {
        bool isSpawned = ResourceManager.Instance.SpendResources(unitType.UnitCost);
        if (!isSpawned)
        {
            Debug.LogWarning("Brak zasobów");
            return false;
        }
            
        Instantiate(unitType.UnitPrefab, transform.position, Quaternion.identity, transform);
        return true;
    }
    
}
