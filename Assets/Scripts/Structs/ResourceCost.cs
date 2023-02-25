using UnityEngine;

[System.Serializable]
public struct ResourceCost
{
    [field: SerializeField] public ResourceSO ResourceType { get; set; }
    [field: SerializeField] public int Amount { get; set; }
}    
