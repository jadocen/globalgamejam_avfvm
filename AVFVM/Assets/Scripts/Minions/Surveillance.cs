using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surveillance : MinionBase
{
    //Angle of rotation per Second
    public float _speed = 60f;
    public float _playerDirection = 0f;

    public Vector3 _rotation;
    public bool _isPlayerDetected = false;

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
        _isPlayerDetected = true;
        StartCoroutine(CO_ResetLevel());
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        _isPlayerDetected = false;
        StopAllCoroutines();
    }

    private IEnumerator CO_ResetLevel()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("RESTART");
    }

    private void FixedUpdate()
    {
        if (!_isPlayerDetected)
        {
            transform.Rotate(_rotation * _speed * Time.deltaTime);
        }
    }
}