using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Induction : MinionBase
{
    public GameObject _inductionHeat;

    public override void Attack()
    {
        base.Attack();
        _inductionHeat.SetActive(false);
        Debug.Log("Induction - Attack");
    }

    public override void ChargeTime()
    {
        base.ChargeTime();
        _inductionHeat.SetActive(true);
        Debug.Log("Induction - Charging");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float knockback = 3.0f;

        collision.gameObject.GetComponent<HealthComponent>().TakeDamage(1f);
        Vector2 impact = (collision.gameObject.transform.position - this.transform.position).normalized * Time.deltaTime;

        collision.gameObject.transform.Translate(impact * knockback);
        Debug.Log("Knockback");
    }
}