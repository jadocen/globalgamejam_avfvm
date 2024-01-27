using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microwave : MinionBase
{
    public GameObject _projectileGO;
    public float _projectileSpeed;
    public Animator _animator;
    public GameObject _spawnPoint;

    public override void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public override IEnumerator CO_Attack()
    {
        base.Attack();
        _animator.SetBool("hasOpened", _isAttacking);
        for (int i = 0; i < 3; i++)
        {
            GameObject spawnedProjectile = Instantiate(_projectileGO, _spawnPoint.transform.position, _spawnPoint.transform.rotation);
            spawnedProjectile.GetComponent<ProjectileBase>().Initialize(_projectileSpeed, 3f);
            yield return new WaitForSeconds(0.5f);
        }
        base.ChargeTime();
        _animator.SetBool("hasOpened", _isAttacking);
        yield return new WaitForSeconds(_attackRecovery);
        _animator.SetTrigger("startCharging");
    }
}
