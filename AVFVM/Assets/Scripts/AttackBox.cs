using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    public EnemyHealth _boss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy Boss"))
        {
            _boss = collision.gameObject.GetComponent<EnemyHealth>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy Boss"))
        {
            _boss = null;
        }
    }
}
