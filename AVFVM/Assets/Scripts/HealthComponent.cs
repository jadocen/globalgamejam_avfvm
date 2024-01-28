using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthComponent : MonoBehaviour
{

    [Header("[STATS]")]
    public float _health;
    public PlayerControls _player;
    public SpriteRenderer _playerColor;

    public void Start()
    {
        _health = 5f;
    }

    public virtual void Update()
    {
        //[DEBUG]
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(1f);
        }
    }

    public virtual void TakeDamage(float damageTaken)
    {
        if (_player._isInvulnerable == false)
        {
            _health -= damageTaken;
            RegulateHealth();
            if (_health > 0)
            {
                AudioManager.instance.PlaySound(Sounds.Damaged);
                _player._isInvulnerable = true;
                StartCoroutine(Invulnerability());
            }
            else
            {
                _player._isInvulnerable = true;
                AudioManager.instance.PlaySound(Sounds.Die);
            }
        }
    }

    public virtual void GainHealth(float addHealth)
    {
        _health += addHealth;
        RegulateHealth();
    }

    private void RegulateHealth()
    {
        if (_health > 10)
        {
            _health = 10f;
        }

        if (_health <= 0)
        {
            _player.gameObject.GetComponent<Animator>().SetBool("Die", true);
        }
    }

    public IEnumerator Invulnerability()
    {
        yield return new WaitForSeconds(4f);
        _player._isInvulnerable = false;
    }

    private void Died()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(2f);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
