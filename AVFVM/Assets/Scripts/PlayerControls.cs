using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("[PLAYER STATS]")]
    public float health;
    public float speed = 10;

    private float lightDamage = 5;
    private float heavyDamage = 10;

    public void Start()
    {
        health = 3f;
    }

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
        RegulateHealth();
    }

    public float PunchAttack()
    {
        Debug.Log(lightDamage);
        return lightDamage;
    }

    public float KickAttack()
    {
        Debug.Log(heavyDamage);
        return heavyDamage;
    }

    private void RegulateHealth()
    {
        if (health > 10)
        {
            health = 10;
        }
    }

    private void Move()
    {
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(rotation, translation, 0);
    }
}