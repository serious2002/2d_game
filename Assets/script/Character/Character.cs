using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header(" Ù–‘")]
    [SerializeField] protected float maxHealth=100;


    [SerializeField] protected float currentHealth=100;

    protected virtual void OnEnable()
    {
        currentHealth=maxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        currentHealth = 0f;
        Destroy(this.gameObject);
    }
}
