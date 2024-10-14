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

    bool _pausedInpt;
    bool _paused;
    bool _onlyPauseOnce;
    void Start()
    {
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
            _paused = !_paused;
            // Cambia la pausa
            if (_paused && _pausedInpt)
            {
                OnPause();
            }
            else if (!_paused && _pausedInpt)
            {
                NotOnPause();
            }
            _onlyPauseOnce = true;
        }
    }

    public void OnPause()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void NotOnPause() 
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
