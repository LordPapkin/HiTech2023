using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ResourceType")]
public class ResourceSO : ScriptableObject
{
   [field: SerializeField] public string NameString { get; private set; }
   [field: SerializeField] public Sprite ResourceIcon { get; private set; }
}
