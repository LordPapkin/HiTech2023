using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private float minTimeBetweenSpawns;
    [SerializeField] private float maxTimeBetweenSpawns;

    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Transform[] spawnPoints;

    private void Start()
    {
        StartCoroutine(SpawningCoins());
    }

    private IEnumerator SpawningCoins()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns));
            var randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(coinPrefab, randomPoint.transform.position + UtilitiesClass.GetRandomDir() * 3f, quaternion.identity);
        }
    }
}
