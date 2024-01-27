using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Janitor : MinionBase
{
    public float _speed = 10;

    public override void Attack()
    {
        base.Attack();
        if(_isAttacking)
        { 
            transform.Translate(Vector2.right * Time.deltaTime * _speed);
        }
    }

    public override void ChargeTime()
    {
        base.ChargeTime();
        //transform.Translate(Vector2.right * Mathf.Sin(1f));
    }
}
