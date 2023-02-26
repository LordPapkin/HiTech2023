using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RangedUnit : BasicUnit
{
    [SerializeField] private float searchRange;
    [SerializeField] private float searchCooldown;
    [SerializeField] private float fireCooldown;
    
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private Transform projectileContainer;
    
    [SerializeField] private BasicTurret target;
    
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
            if(!col.CompareTag("Turret"))
                continue;
            var turret = col.gameObject.GetComponent<BasicTurret>();
            if (turret == null)
                continue;
            if(target == null)
            {
                target = turret;
                continue;
            }
            if (Vector3.Distance(transform.position, target.transform.position) >
                Vector3.Distance(transform.position, turret.transform.position))
            {
                target = turret;
            }
        }
    }

    private void Fire()
    {
        if(target == null)
            return;
        GameObject spawnedProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, quaternion.identity, projectileContainer);
        UnitProjectile projectile = spawnedProjectile.GetComponent<UnitProjectile>();
        projectile.SetTarget(target);
    }
}