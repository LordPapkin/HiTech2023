using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUnit : MonoBehaviour
{
    public Transform Hitbox => hitbox;
    
    [SerializeField] protected HealthSystem healthSystem;
    [SerializeField] protected UnitMovementController unitMovementController;
    [SerializeField] protected int damage;
    [SerializeField] protected Transform hitbox;

    private void Awake()
    {
        healthSystem.Died += OnDied;
        
    }

    private void OnDied(object sender, EventArgs e)
    {
       Destroy(this.gameObject);
    }
}
