using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cebulionCount;
    [SerializeField] private TextMeshProUGUI oilCount;

    private ResourcesListSO resourcesList;
    
    private void OnEnable()
    {
        GameEvents.OnResourceAmountChange += UpdateCounters;
    }

    private void OnDisable()
    {
        GameEvents.OnResourceAmountChange -= UpdateCounters;
    }

    private void Start()
    {
        resourcesList = GameResources.Instance.ResourcesList;
        UpdateCounters();
    }

    private void UpdateCounters()
    {
        cebulionCount.SetText(ResourceManager.Instance.GetResourceAmount(resourcesList.List[0]).ToString());
        oilCount.SetText(ResourceManager.Instance.GetResourceAmount(resourcesList.List[1]).ToString());
    }
}
