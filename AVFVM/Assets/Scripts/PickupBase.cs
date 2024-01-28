using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBase : MinionBase
{
    public Sprite[] _sprites;
    public SpriteRenderer _spriteRenderer;

    public HealthComponent _playerHealth;
    public PlayerControls _playerControl;

    public bool _givesHealth;
    public float _buffAmount;

    public override void Start()
    {
        base.Start();

        if (_givesHealth)
        {
            _spriteRenderer.sprite = _sprites[0];
        }
        else
        {
            _spriteRenderer.sprite = _sprites[1];
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            _playerHealth = other.gameObject.GetComponent<HealthComponent>();
            _playerControl = other.gameObject.GetComponent<PlayerControls>();
            
            TakeEffect();
        }
    }

    public void TakeEffect()
    {
        if (_playerControl != null && _playerHealth != null)
        {
            if (_givesHealth)
            {
                _playerHealth.GainHealth(_buffAmount);
            }
            else if (!_givesHealth)
            {
                _playerControl._speed += _buffAmount;
            }
            AudioManager.instance.PlaySound(Sounds.Pickup);
            StartCoroutine(DestroyThis());
        }
    }

    //IMPLEMENTING UP-DOWN EFFECT ONLY
    private Vector3 _direction;

    public override void Attack() //Janitor Goes Right
    {
        base.Attack();
        _direction = Vector3.up;
    }

    public override void ChargeTime() //Janitor Goes Left
    {
        base.ChargeTime();
        _direction = Vector3.down;
    }

    private void FixedUpdate()
    {
        transform.Translate(_direction * Time.deltaTime);
    }

    IEnumerator DestroyThis()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false; 
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject, .5f);
    }
}
