using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFountain : MinionBase
{
    public GameObject _water;
    public Animator _animator;

    public override void Attack()
    {
        base.Attack();
    }

    public void Activate()
    {
        _water.SetActive(true);
    }

    public override void ChargeTime()
    {
        base.ChargeTime();
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
