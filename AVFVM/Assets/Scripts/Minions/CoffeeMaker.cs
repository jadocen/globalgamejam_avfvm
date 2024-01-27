using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMaker : MonoBehaviour
{
    public Animator _animator;
    public HealthComponent _playerHealth;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<HealthComponent>() != null)
        {
            _playerHealth = collision.GetComponent<HealthComponent>();
            _animator.SetBool("Explode", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<HealthComponent>() != null)
        {
            _playerHealth = null;
            _animator.SetBool("Explode", true);
        }
    }

    public void Damage()
    {
        if (_playerHealth != null)
        {
            _playerHealth.TakeDamage(1f);
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
