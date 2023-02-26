using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BasicTurret : MonoBehaviour
{
    [SerializeField] private float searchRange;
    [SerializeField] private float searchCooldown;
    [SerializeField] private float fireCooldown;

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private Transform projectileContainer;

    [SerializeField] private BasicUnit target;
    
    void Start()
    {
        StartCoroutine(LookForEnemiesCor());
        StartCoroutine(ShootingCor());
    }

    private IEnumerator LookForEnemiesCor()
    {
        while (true)
        {
            yield return new WaitForSeconds(searchCooldown);
            PerformSearch();
        }
    }

    private IEnumerator ShootingCor()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireCooldown);
            Fire();
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

    private void Fire()
    {
        if(target == null)
            return;
        GameObject spawnedProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, quaternion.identity, projectileContainer);
        BasicProjectile projectile = spawnedProjectile.GetComponent<BasicProjectile>();
        projectile.SetTarget(target.Hitbox);
    }
}
