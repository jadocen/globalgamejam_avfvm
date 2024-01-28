using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public GameObject _boss;
    public GameObject _toDestroy;
    public bool _hasEntered;
    public AudioClip _clip;
    public AudioSource _source;

    private void Start()
    {
        _hasEntered = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_hasEntered)
        {
            _hasEntered = true;
            _source.clip = _clip;
            _source.enabled = false;
            _source.enabled = true;
            _boss.SetActive(true);
            Destroy(_toDestroy);
        }
    }
}
