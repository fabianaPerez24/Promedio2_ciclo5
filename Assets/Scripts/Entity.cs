using System;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected int health = 5;

    public event Action<int> OnHealthChanged;

    public virtual void TakeDamage(int damage)
    {
        health -= damage;

        OnHealthChanged?.Invoke(health);

        if (health <= 0)
        {
            Die();
        }
    }

    protected abstract void Die();
}
