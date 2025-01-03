using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdBoss : BossBase
{
    [SerializeField] protected GameObject _aimDirection2;
    [SerializeField] protected GameObject _aimDirection3;
    public GameObject _YouWin;

    public override void Start()
    {
        _aimDirection2 = transform.GetChild(1).gameObject;
        _aimDirection3 = transform.GetChild(2).gameObject;
        base.Start();
        InitializeBoss(5);
    }

    public override IEnumerator Attack1()
    {
        _doNext = 3f;
        float fireRate = 0.2f;
        float random = Random.Range(-60f, 60f);
        Vector3 angle = new Vector3(_aimDirection.transform.eulerAngles.x, _aimDirection.transform.eulerAngles.y, _aimDirection.transform.eulerAngles.z - random);
        GameObject[] array = new GameObject[4] { _projectileGO[0], _projectileGO[3], _projectileGO[4], _projectileGO[5] };
        AudioManager.instance.PlaySound(Sounds.B1A1);
        GameObject projectile = Instantiate(array[Random.Range(0, 4)], transform.position, Quaternion.Euler(angle));
        projectile.GetComponent<ProjectileBase>().Initialize(_projectileSpeed[_choice], 4f);
        yield return new WaitForSeconds(fireRate);
        _canShoot = true;
    }

    public override IEnumerator Attack2()
    {
        _doNext = 3f;
        float fireRate = 2f;
        AudioManager.instance.PlaySound(Sounds.B1A1);
        GameObject projectile = Instantiate(_projectileGO[_choice], transform.position, _aimDirection.transform.rotation);
        projectile.GetComponent<Scattering>().Initialize(_projectileGO[7], _projectileGO[6], 30, _projectileSpeed[_choice], 10f);
        projectile.GetComponent<ProjectileBase>()._target = _player.gameObject;
        projectile.GetComponent<Scattering>()._lastBullet = _projectileGO[8];
        yield return new WaitForSeconds(fireRate);
        _canShoot = true;
    }

    public override IEnumerator Attack3()
    {
        _doNext = 3f;
        float chargeTime = _duration[_choice] - 2f;
        float range = 0.5f;
        yield return new WaitForSeconds(chargeTime);
        for (int j = 0; j < 2; j++)
        {
            AudioManager.instance.PlaySound(Sounds.B1A2);
            for (int i = -60; i <= 60; i += 30)
            {
                Vector3 angle = new Vector3(_aimDirection.transform.eulerAngles.x, _aimDirection.transform.eulerAngles.y, _aimDirection.transform.eulerAngles.z - i);
                GameObject projectile = Instantiate(_projectileGO[_choice], transform.position, Quaternion.Euler(angle));
                projectile.GetComponent<Bomb>().Initialize(true, _projectileSpeed[_choice], 15f, range);
            }
            range += 0.5f;
            yield return new WaitForSeconds(1.5f);
        }
    }
    public override void Die()
    {
        AudioManager.instance.PlaySound(Sounds.YouWin);
        //Play Death animation
        StartCoroutine(YouWin());
    }

    IEnumerator YouWin()
    {
        _YouWin.SetActive(true);
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(0);
    }
}
