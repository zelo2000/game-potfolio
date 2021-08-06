using Assets.Scripts.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    public GameObject UI;

    //
    // Custom Functions
    //
    public void Toggle()
    {
        UI.SetActive(!UI.activeSelf);

        if (UI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneNames.MainMenu);
    }

    public void Retry()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //
    // Unity Functions
    //
    void Update()
    {
        if (GameMaster.GameIsOver)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }
}
