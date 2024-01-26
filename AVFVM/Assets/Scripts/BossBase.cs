using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBase : MonoBehaviour
{
    public GameObject[] _projectileGO;

    [SerializeField] protected float[] _projectileSpeed;
    [SerializeField] protected PlayerControls _player;
    [SerializeField] private EnemyHealth _enemyHealthScript;

    private void Start()
    {
        _enemyHealthScript = GetComponent<EnemyHealth>();
    }

    public void InitializeBoss(float health)
    {
        _enemyHealthScript.InitializeHealth(health);
    }

    public void NextAttack()
    {
        int random = Random.Range(0, 3);
        switch(random)
        {
            case 0:
                Attack1(random);
                break;
            case 1:
                Attack2(random);
                break;
            case 2:
                Attack3(random);
                break;
        }
    }

    public virtual void Attack1(int random)
    {
        
    }

    public virtual void Attack2(int random)
    {

    }

    public virtual void Attack3(int random)
    {

    }

    public virtual void Die()
    {
        //Play Death animation
    }
}
