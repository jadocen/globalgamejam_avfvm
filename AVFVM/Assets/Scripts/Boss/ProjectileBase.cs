using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float _speed;
    public GameObject _target;

    public virtual void Start()
    {

    }

    public virtual void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }

    public void Initialize(float speed, float lifetime)
    {
        _speed = speed;
        Invoke("Lifetime", lifetime);
    }

    public void Lifetime()
    {
        Destroy(gameObject);
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<HealthComponent>())
        {
            collision.gameObject.GetComponent<HealthComponent>().TakeDamage(1f);
        }
        Destroy(gameObject);
    }
}
