using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        //Camera position follows player + offset
        transform.position = player.position + new Vector3(0, 0, -5);
    }
}
