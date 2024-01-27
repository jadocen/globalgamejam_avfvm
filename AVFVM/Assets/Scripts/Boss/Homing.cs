using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : ProjectileBase
{
    private Vector3 _goal;

    void Start()
    {
        
    }

    public override void Update()
    {
        if (_target != null)
        {
            _goal = _target.transform.position;
        }

        Vector2 direction = _goal - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        base.Update();
    }
}
