using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float _speed;

    public virtual void Start()
    {

    }

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
        Debug.Log(collision.gameObject.name);
        collision.gameObject.GetComponent<HealthComponent>().TakeDamage(1f);
        Destroy(gameObject);
    }
}
