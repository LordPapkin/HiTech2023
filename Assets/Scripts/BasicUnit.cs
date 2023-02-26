using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUnit : MonoBehaviour
{
    [SerializeField] protected HealthSystem healthSystem;
    [SerializeField] protected UnitMovementController unitMovementController;
    [SerializeField] protected int damage;

    private void Awake()
    {
        healthSystem.Died += OnDied;
    }

    private void OnDied(object sender, EventArgs e)
    {
       Destroy(this.gameObject);
    }
}
