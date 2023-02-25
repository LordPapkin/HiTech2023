using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTurret : MonoBehaviour
{
    [SerializeField] private float searchRange;
    [SerializeField] private float searchCooldown;
    [SerializeField] private float fireCooldown;

    private GameObject target;
    
    void Start()
    {
        StartCoroutine(LookForEnemies());
    }

    private IEnumerator LookForEnemies()
    {
        yield return new WaitForSeconds(searchCooldown);
        PerformSearch();
    }

    private void PerformSearch()
    {
        
    }
}
