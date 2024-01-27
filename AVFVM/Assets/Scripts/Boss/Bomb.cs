using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : ProjectileBase
{
    public float _range;
    private bool _moving;

    public override void Start()
    {
        Invoke("Stop", _range);
    }

    public override void Update()
    {
        if (_moving)
        {
            base.Update();
        }
    }
    public void Initialize(bool moving, float speed, float lifetime, float range)
    {
        _moving = moving;
        _speed = speed;
        Invoke("Lifetime", lifetime);
        _range = range;
    }

    private void Stop()
    {
        _moving = false;
    }
}
