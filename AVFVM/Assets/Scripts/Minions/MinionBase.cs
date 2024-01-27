using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionBase : MonoBehaviour
{
    [Header("[INITIALIZE STATS]")]
    public float _attackDuration;
    public float _attackRecovery;
    
    public bool _isAttacking;

    public virtual void Start()
    {
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

    public virtual IEnumerator CO_Attack()
    {
        Attack();
        yield return new WaitForSeconds(_attackDuration);


        ChargeTime();
        yield return new WaitForSeconds(_attackRecovery);
        
        StartCoroutine(CO_Attack());
    }
}
