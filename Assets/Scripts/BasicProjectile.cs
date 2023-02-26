using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
   [SerializeField] private int damage;
   [SerializeField] private float moveSpeed;
   
   private Transform target;
   private Vector3 moveDir;

   private void Start()
   {
      Destroy(this.gameObject, 5f);
   }

   private void Update()
   {
      HandleMovementToTarget();
   }

   private void OnTriggerEnter(Collider other)
   {
      Hit(other);
   }

   public void SetTarget(Transform target)
   {
      this.target = target;
      if (this.target == null)
         Destroy(gameObject);
      CalculateMoveDir();
   }

   private void HandleMovementToTarget()
   {
      if(target != null)
         CalculateMoveDir();

      transform.position += moveDir * (moveSpeed * Time.deltaTime);
   }

   private void CalculateMoveDir()
   {
      moveDir = (target.position- transform.position).normalized;
   }

   private void Hit(Collider collider)
   {
      if (collider.CompareTag("Unit"))
      {
         Debug.Log(collider.gameObject.name);
         var healthSystem = collider.gameObject.GetComponentInParent<HealthSystem>();
         if (healthSystem != null)
         {
            healthSystem.TakeDamage(damage);
         }
      }
      Destroy(this.gameObject);
   }
}
