using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float _speed = 10;

    private float _lightDamage = 5;
    private float _heavyDamage = 10;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PunchAttack();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            KickAttack();
        }
    }

    private void LateUpdate()
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
        float translation = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;

        transform.Translate(rotation, translation, 0);
    }
}