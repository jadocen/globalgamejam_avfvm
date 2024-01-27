using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Scattering : ProjectileBase
{
    [SerializeField] protected GameObject _aimDirection;
    public GameObject _scatterBullet;
    public GameObject _middleBullet;
    public GameObject _lastBullet;
    public int _increment;

    public override void Start()
    {
        _aimDirection = transform.GetChild(0).gameObject;
    }

    public override void Update()
    {
        Vector2 direction = _target.transform.position - _aimDirection.transform.position;
        _aimDirection.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        base.Update();
    }
    public void Initialize(GameObject middleGO, GameObject otherGO, int increment, float speed, float lifetime)
    {
        _middleBullet = middleGO;
        _scatterBullet = otherGO;
        _increment = increment;
        _speed = speed;
        Invoke("Lifetime", lifetime);
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<HealthComponent>())
        {
            collision.gameObject.GetComponent<HealthComponent>().TakeDamage(1f);
        }
        else
        {
            for (int i = -30; i <= 30; i += _increment)
            {
                Vector3 angle = new Vector3(_aimDirection.transform.eulerAngles.x, _aimDirection.transform.eulerAngles.y, _aimDirection.transform.eulerAngles.z - i);
                if (i == 0)
                {
                    GameObject projectile = Instantiate(_middleBullet, transform.position, Quaternion.Euler(angle));
                    projectile.GetComponent<ProjectileBase>().Initialize(_speed, 3f);
                    if (projectile.GetComponent<Scattering>())
                    {
                        projectile.GetComponent<Scattering>()._target = _target;
                        projectile.GetComponent<Scattering>().Initialize(_lastBullet, _lastBullet, 15, _speed, 10f);
                    }
                }
                else
                {
                    GameObject projectile = Instantiate(_scatterBullet, transform.position, Quaternion.Euler(angle));
                    projectile.GetComponent<ProjectileBase>().Initialize(_speed, 3f);
                }
            }
        }
        Destroy(gameObject);
    }
}
