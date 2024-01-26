using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBoss : BossBase
{
    public override void Start()
    {
        InitializeBoss(5);
        base.Start();
    }

    public override IEnumerator Attack1()
    {
        float fireRate = 1f;
        GameObject projectile = Instantiate(_projectileGO[_choice], transform.position, _aimDirection.transform.rotation);
        projectile.GetComponent<Projectile>().Initialize(_projectileSpeed[_choice], 3f);
        yield return new WaitForSeconds(fireRate);
        _canShoot = true;
    }
}
