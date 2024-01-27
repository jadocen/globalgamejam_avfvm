using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surveillance : MinionBase
{
    //Angle of rotation per Second
    public float _speed = 60;
    
    private Vector3 _rotation;

    public override void Attack() //Rotate Clockwise
    {
        base.Attack();
        _rotation = new Vector3(0, 0, 1f);
    }

    public override void ChargeTime() //Rest
    {
        base.ChargeTime();
        _rotation = new Vector3(0, 0, 0f);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
    }

    private void FixedUpdate()
    {
        transform.Rotate(_rotation * _speed * Time.deltaTime);
    }
}