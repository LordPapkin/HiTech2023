using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TurretManager : MonoBehaviour
{
    [SerializeField] private GameObject[] turretsPrefabs;
    [SerializeField] private GameObject[] turretPads;
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
        var randomPad = turretPads[Random.Range(0, turretPads.Length)];
        Instantiate(turretsPrefabs[Random.Range(0, turretsPrefabs.Length)], randomPad.transform.position,
            Quaternion.identity, transform);
    }
}
