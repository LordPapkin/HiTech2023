using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BasicTurret : MonoBehaviour
{
    [SerializeField] private float searchRange;
    [SerializeField] private float searchCooldown;
    [SerializeField] private float fireCooldown;

    [SerializeField] private int oilAmount = 5;
    [SerializeField] private int scoreAmount = 100;

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private Transform projectileContainer;

    [SerializeField] private BasicUnit target;

    private TurretPad turretPad;
    private HealthSystem healthSystem;

    private ResourceSO oil;
    
    void Start()
    {
        StartCoroutine(LookForEnemiesCor());
        StartCoroutine(ShootingCor());

        oil = GameResources.Instance.Oil;
        
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.Died += Die;
    }

    public void SetTurretPad(TurretPad builtOnTurretPad)
    {
        turretPad = builtOnTurretPad;
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

    private void Die(object sender, EventArgs e)
    {
        ResourceManager.Instance.AddResource(oil, oilAmount);
        GameStateManager.Instance.AddScore(scoreAmount);
        turretPad.isEmpty = true;
        Destroy(this.gameObject);
    }

}
