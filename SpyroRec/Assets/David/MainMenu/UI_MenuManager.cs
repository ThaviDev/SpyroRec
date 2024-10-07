using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MenuManager : MonoBehaviour
{
    [SerializeField] GameObject _mainMenuPanel;
    [SerializeField] GameObject _optionsPanel;
    void Start()
    {
        _mainMenuPanel.SetActive(true);
        _optionsPanel.SetActive(false);
    }

    void Update()
    {
        
    }
    public void StartGame()
    {

    }
    public void GoToMainMenu()
    {
        _mainMenuPanel.SetActive(true);
        _optionsPanel.SetActive(false);
    }
    public void GoToOptions()
    {
        _mainMenuPanel.SetActive(false);
        _optionsPanel.SetActive(true);
    }
}
