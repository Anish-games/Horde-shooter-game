using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button quitButton;
    [SerializeField] string mainSceneName = "Main";

    void Awake()
    {
        startButton.onClick.AddListener(LoadMainScene);
        quitButton.onClick.AddListener(QuitGame);
    }

    void LoadMainScene()
    {
        SceneManager.LoadScene(mainSceneName);
    }

    void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}