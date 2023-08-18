using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        GameAudio.PlayClickSound();
        Time.timeScale = 1.0f;
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void PauseOn()
    {
        Time.timeScale = 0.0f;
        GameAudio.PlayClickSound();
    }
    public void PauseOff()
    {
        Time.timeScale = 1f;
        GameAudio.PlayClickSound();
    }
}
