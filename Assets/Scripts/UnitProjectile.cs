using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitProjectile : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float moveSpeed;
   
    private BasicTurret target;
    private Vector3 moveDir;

    public void SetDamageToUnits(int dmg)
    {
        damage = dmg;
    }

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

    public void SetTarget(BasicTurret target)
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
        moveDir = (target.transform.position - transform.position).normalized;
    }

    private void Hit(Collider collider)
    {
        if (collider.CompareTag("Turret"))
        {
            var healthSystem = collider.gameObject.GetComponent<HealthSystem>();
            if (healthSystem != null)
            {
                healthSystem.TakeDamage(damage);
            }
        }
        Destroy(this.gameObject);
    }
}
