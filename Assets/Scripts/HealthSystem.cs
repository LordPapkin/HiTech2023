using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public event EventHandler Damaged;
    public event EventHandler Died;
    public event EventHandler Healed;

    [SerializeField] private int healthAmountMax;
    private int healthAmount;

    private void Awake()
    {
        healthAmount = healthAmountMax;
    }
    
    public void TakeDamage(int damage)
    {
        healthAmount -= damage;
        healthAmount = Mathf.Clamp(healthAmount, 0, healthAmountMax);

        //Debug.Log(healthAmount);
        Damaged?.Invoke(this, EventArgs.Empty);

        if (IsDead())
            Died?.Invoke(this, EventArgs.Empty);
    }
    
    public void Heal()
    {
        healthAmount = healthAmountMax;
        Healed?.Invoke(this, EventArgs.Empty);  
    }
    public void Heal(int ammount)
    {
        healthAmount += ammount;
        Healed?.Invoke(this, EventArgs.Empty);  
    }
    
    public float GetHealthAmountNormalized()
    {
        return (float)healthAmount / healthAmountMax;
    }
    
    public bool IsFullHP()
    {
        if(healthAmount == healthAmountMax)
            return true;
        return false;
    }
    
    public bool IsDead()
    {
        if(healthAmount == 0)
            return true;
        return false;
    }
}
