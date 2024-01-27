using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Janitor : MinionBase
{
    private Vector3 _direction;

    public override void Attack() //Janitor Goes Right
    {
        base.Attack();
        _direction = Vector3.right;
    }

    public override void ChargeTime() //Janitor Goes Left
    {
        base.ChargeTime();
        _direction = Vector3.left;
    }

    private void FixedUpdate()
    {
        transform.Translate(_direction * Time.deltaTime);
    }
}
