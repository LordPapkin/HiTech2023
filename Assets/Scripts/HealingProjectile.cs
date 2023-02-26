using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HealingProjectile : MonoBehaviour
{
    [SerializeField] private int healAmmount;
    [SerializeField] private float moveSpeed;
   
    private BasicUnit target;
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

    public void SetTarget(BasicUnit target)
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
        if (collider.CompareTag("Unit"))
        {
            var healthSystem = collider.gameObject.GetComponent<HealthSystem>();
            if (healthSystem != null)
            {
                healthSystem.Heal(healAmmount);
            }
        }
        Destroy(this.gameObject);
    }
}