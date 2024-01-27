using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{

    [Header("[STATS]")]
    public float _health;
    public PlayerControls _player;
    public SpriteRenderer _playerColor;

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
        if (_player._isInvulnerable == false)
        {
            _player._isInvulnerable = true;
            _health -= damageTaken;
            RegulateHealth();
            StartCoroutine(Invulnerability());
        }
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

    public IEnumerator Invulnerability()
    {
        yield return new WaitForSeconds(4f);
        _player._isInvulnerable = false;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
