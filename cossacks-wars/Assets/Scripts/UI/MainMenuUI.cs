using Assets.Scripts.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public string LevelSelector = SceneNames.LevelSelector;

    public void Play()
    {
        SceneManager.LoadScene(LevelSelector);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
