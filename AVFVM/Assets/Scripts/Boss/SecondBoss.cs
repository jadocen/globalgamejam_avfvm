using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBoss : BossBase
{
    [SerializeField] protected GameObject _aimDirection2;

    public override void Start()
    {
        _aimDirection2 = transform.GetChild(1).gameObject;
        base.Start();
        InitializeBoss(75);
    }

    public override void Update()
    {
        if (_player != null)
        {
            Vector2 direction2 = _player.gameObject.transform.position - _aimDirection2.transform.position;
            _aimDirection2.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction2);
        }
        base.Update();
    }

    public override IEnumerator Attack1()
    {
        _doNext = 3f;
        float fireRate = 0.5f;
        AudioManager.instance.PlaySound(Sounds.B1A1);
        GameObject projectile = Instantiate(_projectileGO[_choice], _aimDirection.transform.position, _aimDirection.transform.rotation);
        GameObject projectile2 = Instantiate(_projectileGO[_choice], _aimDirection2.transform.position, _aimDirection2.transform.rotation);
        projectile.GetComponent<ProjectileBase>().Initialize(_projectileSpeed[_choice], 3f);
        projectile2.GetComponent<ProjectileBase>().Initialize(_projectileSpeed[_choice], 3f);
        yield return new WaitForSeconds(fireRate);
        _canShoot = true;
    }

    public override IEnumerator Attack2()
    {
        _doNext = 3f;
        float fireRate = 2f;
        AudioManager.instance.PlaySound(Sounds.B2A2);
        GameObject projectile = Instantiate(_projectileGO[_choice], _aimDirection.transform.position, _aimDirection.transform.rotation);
        projectile.GetComponent<ProjectileBase>()._target = _player.gameObject;
        projectile.GetComponent<ProjectileBase>().Initialize(_projectileSpeed[_choice], 5f);
        yield return new WaitForSeconds(0.2f);
        AudioManager.instance.PlaySound(Sounds.B2A2);
        GameObject projectile2 = Instantiate(_projectileGO[_choice], _aimDirection.transform.position, _aimDirection.transform.rotation);
        projectile2.GetComponent<ProjectileBase>()._target = _player.gameObject;
        projectile2.GetComponent<ProjectileBase>().Initialize(_projectileSpeed[_choice], 5f);
        yield return new WaitForSeconds(fireRate);
        _canShoot = true;
    }

    public override IEnumerator Attack3()
    {
        _doNext = 4f;
        float fireRate = 2f;
        GameObject projectile = Instantiate(_projectileGO[_choice], transform.position, _aimDirection.transform.rotation);
        AudioManager.instance.PlaySound(Sounds.B1A1);
        projectile.GetComponent<Scattering>().Initialize(_projectileGO[3], _projectileGO[3], 30, _projectileSpeed[_choice], 10f);
        projectile.GetComponent<ProjectileBase>()._target = _player.gameObject;
        yield return new WaitForSeconds(fireRate);
        _canShoot = true;
    }
}
