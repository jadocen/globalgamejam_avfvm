using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject _next;

    public void Activate()
    {
        _next.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float knockback = 3.0f;

        if (collision.gameObject.GetComponent<HealthComponent>())
        {
            collision.gameObject.GetComponent<HealthComponent>().TakeDamage(1f);
            Vector2 impact = (collision.gameObject.transform.position - this.transform.position).normalized * Time.deltaTime;

            collision.gameObject.transform.Translate(impact * knockback);
        }
    }
}
