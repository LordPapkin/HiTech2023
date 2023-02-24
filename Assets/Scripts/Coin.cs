using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float coinLifeTime;
    
    private void Start()
    {
        Destroy(this.gameObject, coinLifeTime);
    }

    private void OnMouseDown()
    {
        ResourceManager.Instance.AddResource(GameResources.Instance.Cebulion, 1);
    }
}
