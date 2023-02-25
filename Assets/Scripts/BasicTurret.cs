using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTurret : MonoBehaviour
{
    [SerializeField] private float searchRange;
    [SerializeField] private float searchCooldown;
    [SerializeField] private float fireCooldown;

    [SerializeField] private BasicUnit target;
    
    void Start()
    {
        StartCoroutine(LookForEnemies());
    }

    private IEnumerator LookForEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(searchCooldown);
            PerformSearch();
        }
    }

    private void PerformSearch()
    {
        target = null;
        Collider[] colliders = Physics.OverlapSphere(transform.position, searchRange);
        
        foreach (Collider col in colliders)
        {
            if(!col.CompareTag("Unit"))
                continue;
            var unit = col.gameObject.GetComponent<BasicUnit>();
            if (unit == null)
                continue;
            if(target == null)
            {
                target = unit;
                continue;
            }
            if (Vector3.Distance(transform.position, target.transform.position) >
                Vector3.Distance(transform.position, unit.transform.position))
            {
                target = unit;
            }
        }
    }
}
