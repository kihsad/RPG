using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject _settingsPanel;

    public void ShowSettings()
    {
        _settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        _settingsPanel.SetActive(false);
    }
    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
