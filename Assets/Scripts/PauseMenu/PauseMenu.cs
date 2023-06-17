using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    [SerializeField]
    private Button _exitButton;
    [SerializeField]
    private Button _unpauseButton;
    [SerializeField]
    private Button _startMenuButton;


    private void Awake()
    {
        _exitButton.onClick.AddListener(ExitGame);
        _unpauseButton.onClick.AddListener(ReturnToGame);
        _startMenuButton.onClick.AddListener(ToStartMenu);
        gameObject.SetActive(false);
    }

    private void ToStartMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPaused = true;
#elif UNITY_STANDALONE
        Application.Quit();
#endif
    }

    private void ReturnToGame()
    {
        gameObject.SetActive(false);
    }
}
