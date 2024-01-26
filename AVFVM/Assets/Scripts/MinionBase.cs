using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionBase : MonoBehaviour
{
    [Header("[INITIALIZE STATS]")]
    public EnemyHealth _enemyHealth;
    public float _attackDuration;
    public float _attackRecovery;

    public bool _isAttacking;

    public void Start()
    {
        _enemyHealth = this.GetComponent<EnemyHealth>();
        _isAttacking = false;

        StartCoroutine(CO_Attack());
    }

    public void Update()
    {
        
    }

    public virtual void Attack()
    {
        _isAttacking = true;
    }

    public virtual void ChargeTime()
    {
        _isAttacking = false;
    }

    private IEnumerator CO_Attack()
    {
        Attack();
        yield return new WaitForSeconds(_attackDuration);


        ChargeTime();
        yield return new WaitForSeconds(_attackRecovery);
        
        StartCoroutine(CO_Attack());
    }
}
