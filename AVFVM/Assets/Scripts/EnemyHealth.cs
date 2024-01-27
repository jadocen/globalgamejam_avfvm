using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float _health;
    public float _maxHealth;

    public void InitializeHealth(float initialHealth)
    {
        _maxHealth = initialHealth;
        _health = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        CheckHealth();
    }

    public void GainHealth(float heal)
    {
        _health += heal;
        CheckHealth();
    }

    public void CheckHealth()
    {
        if (_health <= 0)
        {
            if (this.gameObject.GetComponent<BossBase>() != null)
            {
                this.gameObject.GetComponent<BossBase>().Die();
            }

            //hi moises sorry sa code na to HAHAHAHAHA 
            Destroy(this.gameObject.GetComponent<SpriteRenderer>());
        }

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }
}
