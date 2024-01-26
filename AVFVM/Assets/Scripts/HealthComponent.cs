using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [Header("[STATS]")]
    public float _health;

    public void Start()
    {
        _health = 3f;
    }

    public void Update()
    {
        //[DEBUG]
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(1f);
        }
    }

    public void TakeDamage(float damageTaken)
    {
        _health -= damageTaken;
        RegulateHealth();
    }

    public void GainHealth(float addHealth)
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
