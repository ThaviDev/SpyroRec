using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_MenuManager : MonoBehaviour
{
    [SerializeField] GameObject _mainMenuPanel;
    [SerializeField] GameObject _optionsPanel;
    [SerializeField] string _sceneStartName;
    [SerializeField] EventSystem _eventSystm;
    [SerializeField] Button _firstSelectedMenu;
    [SerializeField] Button _firstSelectedOptions;

    void Start()
    {
        _mainMenuPanel.SetActive(true);
        _optionsPanel.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(_sceneStartName);
    }
    public void GoToMainMenu()
    {
        //_eventSystm.firstSelectedGameObject = _firstSelectedMenu.gameObject;
        _eventSystm.SetSelectedGameObject(_firstSelectedMenu.gameObject);
        _mainMenuPanel.SetActive(true);
        _optionsPanel.SetActive(false);
    }
    public void GoToOptions()
    {
        //_eventSystm.firstSelectedGameObject = _firstSelectedOptions.gameObject;
        _eventSystm.SetSelectedGameObject(_firstSelectedOptions.gameObject);

        _mainMenuPanel.SetActive(false);
        _optionsPanel.SetActive(true);
    }
}
