using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Guard : MinionBase
{
    //Angle of rotation per Second
    public float _speed = 60f;
    public float _detectionWindow = 3f;
    public Animator animator;

    public SpriteRenderer _spriteRenderer;
    public Vector3 _rotation;
    public bool _isPlayerDetected = false;

    public override void Start()
    {
        base.Start();
    }

    public override void Attack() //Rotate Clockwise
    {
        base.Attack();
        _rotation = new Vector3(0, 0, 1f);
    }

    public override void ChargeTime() //Rest
    {
        base.ChargeTime();
        _rotation = new Vector3(0, 0, 0f);
    }

    public void OnTriggerEnter2D(Collider2D other) //DETECTION - Start
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isPlayerDetected = true;
            animator.SetBool("detected", _isPlayerDetected);
            StartCoroutine(CO_ResetLevel());
        }
        else
        {
            Debug.Log("ENTER Not Player");
            _isPlayerDetected = false;
            animator.SetBool("detected", _isPlayerDetected);
        }
    }

    public void OnTriggerExit2D(Collider2D other) //DETECTION - Stops
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isPlayerDetected = false;
            animator.SetBool("detected", _isPlayerDetected);

            //Cancels restart if player leaves FOV
            StopAllCoroutines();
            _spriteRenderer.color = Color.white;
        }
        else
        {
            Debug.Log("exit Not Player");
            _isPlayerDetected = false;
            animator.SetBool("detected", _isPlayerDetected);
        }
    }

    private IEnumerator CO_ResetLevel()
    {
        _spriteRenderer.color = Color.red;
        //Starts counting down from 3, once player gets detected
        yield return new WaitForSeconds(_detectionWindow);

        //Level Restarts if player is still detected after 3s
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    private void FixedUpdate()
    {
        if (!_isPlayerDetected)
        {
            transform.Rotate(_rotation * _speed * Time.deltaTime);
        }
    }
}