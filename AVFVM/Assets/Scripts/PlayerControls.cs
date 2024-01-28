using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float _speed;
    public Animator _animator;
    public Rigidbody2D _rb;
    public GameObject _pivotPoint;
    public AttackBox _attackBox;
    public bool _canMove;
    private Vector2 _movement;
    private float _lightDamage;
    private float _heavyDamage;
    private bool _canAttack;
    public bool _isInvulnerable;
    private bool _startModulating;
    private HealthComponent _healthComponent;

    private void Start()
    {
        _speed = 4f;
        _lightDamage = 5;
        _heavyDamage = 10;
        _canAttack = true;
        _isInvulnerable = false;
        _startModulating = true;
        _healthComponent = GetComponent<HealthComponent>();
        _healthComponent._player = this;
        _canMove = true;
    }

    public void Update()
    {
        _movement.x = Input.GetAxis("Horizontal");
        _movement.y = Input.GetAxis("Vertical");

        _animator.SetFloat("Horizontal", _movement.x);
        _animator.SetFloat("Vertical", _movement.y);
        _animator.SetFloat("Speed", _movement.sqrMagnitude);

        if (_canAttack)
        {
            if (Input.GetKeyDown(KeyCode.X) && _movement == Vector2.zero)
            {
                _canAttack = false;
                PunchAttack(0.6f);
            }
            else if (Input.GetKeyDown(KeyCode.Z) && _movement == Vector2.zero)
            {
                _canAttack = false;
                KickAttack(1.2f);
            }
        }

        if (_movement != Vector2.zero)
        {
            _animator.SetFloat("HorizontalIdle", _movement.x);
            if (_movement.x > 0)
            {
                _animator.SetFloat("HorizontalIdle", 0.1f);
            }
            _animator.SetFloat("VerticalIdle", _movement.y);
        }

        if (_isInvulnerable && _startModulating)
        {
            _startModulating = false;
            StartCoroutine(ModulateColor());
        }
    }

    private void FixedUpdate()
    {
        if (_canMove)
        {
            Move();
        }
    }

    public IEnumerator ModulateColor()
    {
        SpriteRenderer playerColor = gameObject.GetComponent<SpriteRenderer>();
        if (playerColor.color.a > 0.3f)
        {
            playerColor.color = new Color(1f, 0, 0, 0.3f);
        }
        else
        {
            playerColor.color = new Color(1, 0, 0, 0.8f);
        }
        yield return new WaitForSeconds(0.05f);
        if (_isInvulnerable)
        {
            StartCoroutine(ModulateColor());
        }
        else
        {
            playerColor.color = Color.white;
            _startModulating = true;
        }
    }

    public void PunchAttack(float cooldown)
    {
        _animator.SetTrigger("isPunching");
        AudioManager.instance.PlaySound(Sounds.Punch);
        if (_attackBox._boss != null)
        {
            _attackBox._boss.TakeDamage(_lightDamage);
        }
        Invoke("Attack", cooldown);
    }

    public void KickAttack(float cooldown)
    {
        _animator.SetTrigger("isKicking");
        AudioManager.instance.PlaySound(Sounds.Kick);
        if (_attackBox._boss != null)
        {
            _attackBox._boss.TakeDamage(_heavyDamage);
        }
        Invoke("Attack", cooldown);
    }

    public void AttackDone()
    {
        _animator.SetTrigger("AttackDone");
    }

    private void Move()
    {
        transform.Translate(_movement * _speed * Time.deltaTime);
        
        if (Mathf.Abs(_animator.GetFloat("HorizontalIdle")) > Mathf.Abs(_animator.GetFloat("VerticalIdle")))
        {
            if (_animator.GetFloat("HorizontalIdle") > 0)
            {
                _pivotPoint.transform.rotation = Quaternion.Euler(0, 0, -90);
                
            }
            else
            {
                _pivotPoint.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
        }
        else
        {
            if (_animator.GetFloat("VerticalIdle") > 0)
            {
                _pivotPoint.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                _pivotPoint.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
        }
    }

    public void Attack()
    {
        _canAttack = true;
    }
}