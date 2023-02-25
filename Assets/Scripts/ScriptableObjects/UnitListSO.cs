using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/UnitsList")]
public class UnitListSO : ScriptableObject
{
    [field: SerializeField] public List<UnitSO> UnitsList { get; private set; }
}
