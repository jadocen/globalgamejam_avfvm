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
        float fireRate = 0.8f;
        GameObject projectile = Instantiate(_projectileGO[_choice], transform.position, _aimDirection.transform.rotation);
        projectile.GetComponent<Projectile>().Initialize(_projectileSpeed[_choice], 3f);
        yield return new WaitForSeconds(fireRate);
        _canShoot = true;
    }

    public override IEnumerator Attack2()
    {
        float fireRate = 1.3f;
        for (int i = -30; i <= 30; i += 15)
        {
            Vector3 angle = new Vector3(_aimDirection.transform.eulerAngles.x, _aimDirection.transform.eulerAngles.y, _aimDirection.transform.eulerAngles.z - i);
            GameObject projectile = Instantiate(_projectileGO[_choice], transform.position, Quaternion.Euler(angle));
            projectile.GetComponent<Projectile>().Initialize(_projectileSpeed[_choice], 3f);
        }
        yield return new WaitForSeconds(fireRate);
        _canShoot = true;
    }
}
