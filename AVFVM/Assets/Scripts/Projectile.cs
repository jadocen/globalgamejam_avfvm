using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float _speed;

    public void Initialize(float speed, float lifetime)
    {
        _speed = speed;
        Invoke("Lifetime", lifetime);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }

    public void Lifetime()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<HealthComponent>().TakeDamage(1f);
        Destroy(gameObject);
    }
}
