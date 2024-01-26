using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBoss : BossBase
{
    private void Start()
    {
        InitializeBoss(5);
        Attack1(0);
    }

    //Shoot snacks to direction of player
    public override void Attack1(int random)
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject projectile = Instantiate(_projectileGO[random], transform.position, Quaternion.identity);
            projectile.GetComponent<Projectile>()._speed = _projectileSpeed[0];
            projectile.GetComponent<Projectile>()._target = _player;
        }
        Invoke("NextAttack", 3f);
    }


}
