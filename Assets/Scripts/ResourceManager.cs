using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance => instance;
    private static ResourceManager instance;
    private Dictionary<ResourceSO, int> resourceDictionary;
    private ResourcesListSO resourcesList;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
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
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    AddResource(resourcesList.List[0], 10);
        //    AddResource(resourcesList.List[1], 10);
        //}
        //
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    var cost = new ResourceCost
        //    {
        //        ResourceType = resourcesList.List[0],
        //        Amount = 100
        //    };
        //    SpendResources(cost);
        //}
        //
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    Debug.Log(resourcesList.List[0].NameString + " " + resourceDictionary[resourcesList.List[0]]);
        //}
    }

    public void AddResource(ResourceSO type, int amount)
    {
        if(!resourceDictionary.ContainsKey(type))
            return;

        resourceDictionary[type] += amount;
        GameEvents.ResourceAmountChange();
    }

    public bool SpendResources(ResourceCost resourceCost)
    {
        if (resourceDictionary[resourceCost.ResourceType] < resourceCost.Amount)
            return false;
        
        resourceDictionary[resourceCost.ResourceType] -= resourceCost.Amount;
        GameEvents.ResourceAmountChange();
        return true;
    }

    public bool SpendResources(ResourceCost[] resourceCostArray)
    {
        if (!CanAfford(resourceCostArray))
            return false;
        
        foreach (var resourceCost in resourceCostArray)
        {
            resourceDictionary[resourceCost.ResourceType] -= resourceCost.Amount;
        }
        GameEvents.ResourceAmountChange();
        return true;
    }

    public bool CanAfford(ResourceCost[] resourceCostArray)
    {
        foreach (var resourceCost in resourceCostArray)
        {
            if (resourceDictionary[resourceCost.ResourceType] < resourceCost.Amount)
                return false;
        }
        return true;
    }
    
    public bool CanAfford(ResourceCost resourceCost)
    {
        if (resourceDictionary[resourceCost.ResourceType] < resourceCost.Amount)
            return false;
        return true;
    }

    public int GetResourceAmount(ResourceSO resource)
    {
        return resourceDictionary[resource];
    }
    
}
