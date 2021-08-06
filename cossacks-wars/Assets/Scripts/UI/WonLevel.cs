using Assets.Scripts.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WonLevel : MonoBehaviour
{
    public string NextLevel = SceneNames.Level2;

    public void Continue()
    {
        SceneManager.LoadScene(NextLevel);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneNames.MainMenu);
    }
}
