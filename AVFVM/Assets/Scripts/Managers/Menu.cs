using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public bool _isPaused;
    public float _currentTimeScale;
    public GameObject _pauseUI;

    private void Start()
    {
        _isPaused = false;
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (_isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void StartGame()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        Cursor.visible = true;
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        Cursor.visible = false;
        _pauseUI.SetActive(false);
        Time.timeScale = _currentTimeScale;
        _isPaused = false;
    }

    public void Pause()
    {
        Cursor.visible = true;
        _currentTimeScale = Time.timeScale;
        _pauseUI.SetActive(true);
        Time.timeScale = 0f;
        _isPaused = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
