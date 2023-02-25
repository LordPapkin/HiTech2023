using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUnit : MonoBehaviour
{
    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private UnitMovementController unitMovementController;

    private void Awake()
    {
        healthSystem.Died += OnDied;
    }

    private void OnDied(object sender, EventArgs e)
    {
       Destroy(this.gameObject);
    }
}
