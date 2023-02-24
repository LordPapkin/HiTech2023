using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ResourcesList")]
public class ResourcesListSO : ScriptableObject
{
    [field: SerializeField] public List<ResourceSO> List { get; private set; }
}
