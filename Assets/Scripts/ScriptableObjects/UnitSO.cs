using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Unit")]
public class UnitSO : ScriptableObject
{
    [field: SerializeField] public string NameString { get; private set; }
    [field: SerializeField] public GameObject UnitPrefab { get; private set; }
    [field: SerializeField] public ResourceCost[] UnitCost { get; private set; }
    [field: SerializeField] public float UnitCooldown { get; private set; }
}
