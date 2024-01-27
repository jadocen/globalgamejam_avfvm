using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float _speed = 10;
    public Animator _animator;
    public Rigidbody2D _rb;
    public GameObject _pivotPoint;
    public GameObject _attackBox;
    private Vector2 _movement;
    private float _lightDamage = 5;
    private float _heavyDamage = 10;

    public void Update()
    {
        _movement.x = Input.GetAxis("Horizontal");
        _movement.y = Input.GetAxis("Vertical");

        _animator.SetFloat("Horizontal", _movement.x);
        _animator.SetFloat("Vertical", _movement.y);
        _animator.SetFloat("Speed", _movement.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            PunchAttack();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            KickAttack();
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

        //Quaternion rotation = Quaternion.LookRotation(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) - transform.position);
        //_attackBox.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0);
    }

    private void FixedUpdate()
    {
        Move();
    }

    public float PunchAttack()
    {
        Debug.Log(_lightDamage);
        return _lightDamage;
    }

    public float KickAttack()
    {
        Debug.Log(_heavyDamage);
        return _heavyDamage;
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
}