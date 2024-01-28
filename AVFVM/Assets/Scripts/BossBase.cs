using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public enum Triggers
{
    Attack1,
    Attack2,
    Attack3
}

public class BossBase : MonoBehaviour
{
    public GameObject[] _projectileGO;

    [SerializeField] protected bool _canShoot;
    [SerializeField] protected bool _isAttacking;
    [SerializeField] protected bool _setDuration;
    [SerializeField] protected bool _reset;
    [SerializeField] protected int _choice;
    [SerializeField] protected float[] _duration;
    [SerializeField] protected float _currentDuration;
    [SerializeField] protected float[] _projectileSpeed;
    [SerializeField] protected float _doNext;
    [SerializeField] protected GameObject _aimDirection;
    [SerializeField] protected PlayerControls _player;
    [SerializeField] private EnemyHealth _enemyHealthScript;
    [SerializeField] protected Animator _animator;

    public virtual void Start()
    {
        _animator = GetComponent<Animator>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _player = player.GetComponent<PlayerControls>();
        _enemyHealthScript = GetComponent<EnemyHealth>();
        _reset = false;
        _canShoot = false;
        _isAttacking = false;
        _aimDirection = transform.GetChild(0).gameObject;
        Invoke("StartAttacking", 3f);
        _animator.SetTrigger("Choose");
    }

    public virtual void Update()
    {
        if (_player != null)
        {
            Vector2 direction = _player.gameObject.transform.position - _aimDirection.transform.position;
            _aimDirection.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);

            if (_isAttacking && _canShoot)
            {
                _canShoot = false;
                Attack();
            }

            if (_currentDuration > 0)
            {
                _currentDuration -= 1f * Time.deltaTime;
            }
            else if (_reset)
            {
                _animator.SetTrigger("AttackDone");
                _reset = false;
                StartCoroutine(NextAttack());
            }
        }
        
    }

    public void StartAttacking()
    {
        _choice = Random.Range(0, _duration.Length);
        _animator.SetTrigger(Enum.GetName(typeof(Triggers), _choice));
        _currentDuration = _duration[_choice];
        _reset = true;
        _canShoot = true;
        _isAttacking = true;
    }

    public virtual IEnumerator NextAttack()
    {
        _isAttacking = false;
        yield return new WaitForSeconds(2f);
        AudioManager.instance.PlaySound(Sounds.Choose);
        _animator.SetTrigger("Choose");
        yield return new WaitForSeconds(_doNext);
        StartAttacking();
    }

    public void InitializeBoss(float health)
    {
        _enemyHealthScript.InitializeHealth(health);
    }

    public void Attack()
    {
        switch(_choice)
        {
            case 0:
                StartCoroutine(Attack1());
                break;
            case 1:
                StartCoroutine(Attack2());
                break;
            case 2:
                StartCoroutine(Attack3());
                break;
        }
    }

    public virtual IEnumerator Attack1()
    {
        yield return new WaitForSeconds(1f);
        _canShoot = true;
    }

    public virtual IEnumerator Attack2()
    {
        yield return new WaitForSeconds(1f);
        _canShoot = true;
    }

    public virtual IEnumerator Attack3()
    {
        yield return new WaitForSeconds(1f);
        _canShoot = true;
    }

    public virtual IEnumerator CO_NextScene()
    {
        Debug.Log("Next Scene Loading");    
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public virtual void Die()
    {
        AudioManager.instance.PlaySound(Sounds.BossDefeat);
        //Play Death animation
        StartCoroutine(CO_NextScene());
    }
}
