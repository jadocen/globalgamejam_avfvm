using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microwave : MinionBase
{
    public GameObject _projectileGO;
    public float _projectileSpeed;

    public override void Attack()
    {
        base.Attack();

        _projectileGO = Instantiate(_projectileGO, transform.position, transform.rotation);
        _projectileGO.GetComponent<Projectile>().Initialize(_projectileSpeed, 3f);
    }

    public override void ChargeTime()
    {
        base.ChargeTime();
    }
}
