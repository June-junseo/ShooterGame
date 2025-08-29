using System;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable
{
    public float startHealth = 100f;
    public float health { get; protected set; }
    public bool dead { get; protected set; }

    public event Action OnDeath;

    protected virtual void OnEnable()
    {
        dead = false;
        health = startHealth;
    }

    public virtual void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        health -= damage;

        if(health <= 0 && !dead)
        {
            Die();
        }
    }

    public void RestoreHealth(float newHealth)
    {
        if(dead)
        {
            return;
        }

        health += newHealth;
    }

    public virtual void Die()
    {
        if(OnDeath != null)
        {
            OnDeath();
        }

        dead = true;
    }

   
}
