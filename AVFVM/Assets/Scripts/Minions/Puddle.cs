using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour
{
    public bool _moving;
    public PlayerControls _player;
    public GameObject _pivotPoint;

    private void Update()
    {
        if (_moving)
        {
            switch (_pivotPoint.transform.eulerAngles.z)
            {
                case 90:
                    _player.transform.Translate(Vector3.left * _player._speed * Time.deltaTime);
                    break;
                case 270:
                    _player.transform.Translate(Vector3.right * _player._speed * Time.deltaTime);
                    break;
                case 0:
                    _player.transform.Translate(Vector3.up * _player._speed * Time.deltaTime);
                    break;
                case 180:
                    _player.transform.Translate(Vector3.down * _player._speed * Time.deltaTime);
                    break;
            }
            Debug.Log(_pivotPoint.transform.eulerAngles.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControls>() != null)
        {
            _player = collision.GetComponent<PlayerControls>();
            _pivotPoint = _player.transform.GetChild(0).gameObject;
            _moving = true;
            _player._canMove = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControls>() != null)
        {
            _player._canMove = true;
            _player = null;
            _pivotPoint = null;
            _moving = false;
        }
    }
}
