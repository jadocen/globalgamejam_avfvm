using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float _speed;
    public PlayerControls _target;

    private void Start()
    {
        transform.LookAt(_target.transform.position);
    }

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

}
