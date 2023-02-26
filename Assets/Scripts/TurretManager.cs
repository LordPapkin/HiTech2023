using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TurretManager : MonoBehaviour
{
    [SerializeField] private GameObject[] turretsPrefabs;
    [SerializeField] private TurretPad[] turretPads;
    [SerializeField] private Transform turretsParent;

    [SerializeField] private float minTimeToSpawnNextTurret;
    [SerializeField] private float maxTimeToSpawnNextTurret;

    private void Start()
    {
        StartCoroutine(SpawningTurretsCor());
    }

    private IEnumerator SpawningTurretsCor()
    {
        while (true)
        {
            SpawnRandomTurret();
            yield return new WaitForSeconds(Random.Range(minTimeToSpawnNextTurret, maxTimeToSpawnNextTurret));
        }
    }

    private void SpawnRandomTurret()
    {
        int i = 0;
        TurretPad randomPad = null;
        while (i<10)
        {
            randomPad = turretPads[Random.Range(0, turretPads.Length)];
            if(randomPad.isEmpty)
                break;
            i++;
        }
        
        if(randomPad == null)
            return;

        randomPad.isEmpty = false;
        var turret = Instantiate(turretsPrefabs[Random.Range(0, turretsPrefabs.Length)], randomPad.transform.position,
            Quaternion.identity, turretsParent);
        turret.GetComponent<BasicTurret>().SetTurretPad(randomPad);
    }
}
