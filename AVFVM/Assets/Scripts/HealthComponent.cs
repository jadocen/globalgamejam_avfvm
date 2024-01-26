using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public CapsuleCollider2D _hitBox;

    [Header("[STATS]")]
    public float _health;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        TakeDamage(1f);
    }

    public void Start()
    {
        _health = 3f;
    }

    public virtual void Update()
    {
        //[DEBUG]
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(1f);
        }
    }

    public virtual void TakeDamage(float damageTaken)
    {
        _health -= damageTaken;
        RegulateHealth();
    }

    public virtual void GainHealth(float addHealth)
    {
        _health += addHealth;
        RegulateHealth();
    }

    private void RegulateHealth()
    {
        if (_health > 10)
        {
            _health = 10f;
        }

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Death");
    }
}
