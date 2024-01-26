using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBase : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealthScript;

    public void InitializeBoss(float health)
    {
        _enemyHealthScript.InitializeHealth(health);
    }

    public virtual void Attack1()
    {

    }

    public virtual void Attack2()
    {

    }

    public virtual void Attack3()
    {

    }
}
