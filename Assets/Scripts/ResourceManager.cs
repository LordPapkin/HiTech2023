using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }
    private Dictionary<ResourceSO, int> resourceDictionary;
    private ResourcesListSO resourcesList;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        resourcesList = GameResources.Instance.ResourcesList;
        resourceDictionary = new Dictionary<ResourceSO, int>();
        foreach (var resource in resourcesList.List)
        {
            resourceDictionary.Add(resource, 0);
        }
    }

    private void Update()
    {
        // for test
        if (Input.GetKeyDown(KeyCode.A))
        {
            AddResource(resourcesList.List[0], 10);
            AddResource(resourcesList.List[1], 10);
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            var cost = new ResourceCost
            {
                ResourceType = resourcesList.List[0],
                Amount = 100
            };
            SpendResources(cost);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log(resourcesList.List[0].NameString + " " + resourceDictionary[resourcesList.List[0]]);
        }
    }

    public void AddResource(ResourceSO type, int amount)
    {
        if(!resourceDictionary.ContainsKey(type))
            return;
        
        resourceDictionary[type] += amount;
    }

    public bool SpendResources(ResourceCost resourceCost)
    {
        if (resourceDictionary[resourceCost.ResourceType] < resourceCost.Amount)
            return false;
        resourceDictionary[resourceCost.ResourceType] -= resourceCost.Amount;
        return true;
    }

    public bool SpendResources(ResourceCost[] resourceCostArray)
    {
        foreach (var resourceCost in resourceCostArray)
        {
            if (resourceDictionary[resourceCost.ResourceType] < resourceCost.Amount)
                return false;
        }
        
        foreach (var resourceCost in resourceCostArray)
        {
            resourceDictionary[resourceCost.ResourceType] -= resourceCost.Amount;
        }
        return true;
    }
    
}
