using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    MyAudioManager _audioManager;
    MyInputManager _inpt;

    [Header("Referencias Interfaz")]
    [SerializeField] GameObject _pausePanel;

    [Header("Variables")]
    [SerializeField] string _mainMenuName;

    bool _pausedInpt;
    bool _paused;
    bool _onlyPauseOnce;
    void Start()
    {
        NotOnPause();
        _inpt = FindAnyObjectByType<MyInputManager>();
    }

    void Update()
    {
        _pausedInpt = _inpt.GetStart;

        if (!_pausedInpt)
        {
            _onlyPauseOnce = false;
        }

        if (_pausedInpt && !_onlyPauseOnce)
        {
            TogglePauseBtn();
        }
    }

    public void TogglePauseBtn()
    {
        print("DetectoPausa");
        _paused = !_paused;
        // Cambia la pausa
        if (_paused)
        {
            OnPause();
        }
        else if (!_paused)
        {
            NotOnPause();
        }
        _onlyPauseOnce = true;
    }

    void OnPause()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    void NotOnPause() 
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(_mainMenuName);
    }
}
