using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class SpecialUnit : BasicUnit
{
    public enum SpecialCase
    {
        Roomba=1,
        Drone=2,
        Kerfus=3
    }

    [SerializeField] private SpecialCase unitTier;
    [SerializeField] private float searchCooldown;
    [SerializeField] private float searchRange;
    
    [SerializeField] private float healingCooldown;

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private Transform projectileContainer;
    
    [SerializeField] private BasicUnit target;
    private bool isHealer = false;
    private void Start()
    {
        switch (unitTier)
        {
            case SpecialCase.Roomba:
                damage = 60;
                //what is the purpose in any of this... ~suicide roomba
                break;
            case SpecialCase.Drone:
                damage = 50;
                unitMovementController.velocity = 18f;
                //speedo haiai
                break;
            case SpecialCase.Kerfus:
                damage = 50;
                isHealer = true;
                //lemme nurse you, nya
                break;
            default:
                return;
        }

        if (isHealer)
        {
            StartCoroutine(LookForAlliesCor());
            StartCoroutine(HealingCor());
        }
    }
    
    private IEnumerator LookForAlliesCor()
    {
        while (true)
        {
            yield return new WaitForSeconds(searchCooldown);
            PerformSearch();
        }
    }
    private IEnumerator HealingCor()
    {
        while (true)
        {
            yield return new WaitForSeconds(healingCooldown);
            Heal();
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
            var ally = col.gameObject.GetComponent<BasicUnit>();
            if (ally == null)
                continue;
            if(target == null)
            {
                target = ally;
                continue;
            }
            if (Vector3.Distance(transform.position, target.transform.position) >
                Vector3.Distance(transform.position, ally.transform.position))
            {
                target = ally;
            }
        }
    }
    private void Heal()
    {
        if(target == null)
            return;
        GameObject spawnedProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, quaternion.identity, projectileContainer);
        HealingProjectile projectile = spawnedProjectile.GetComponent<HealingProjectile>();
        projectile.SetTarget(target);
    }
}
