using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Image _health;

    private void Update()
    {
        _health.fillAmount = player.GetComponent<HealthComponent>()._health / 10;

        //Camera position follows player + offset
        if (player != null)
        {
            transform.position = player.position + new Vector3(0, 0, -5);
        }
    }
}
