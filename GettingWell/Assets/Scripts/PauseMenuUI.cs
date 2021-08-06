using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    public GameObject UI;
    public string NextLevelToLoad;

    public void Toggle()
    {
        UI.SetActive(!UI.activeSelf);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Retry()
    {
        Toggle();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(NextLevelToLoad);
    }

    public void ContinueLevel()
    {
        Time.timeScale = 1f;
        Toggle();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            Toggle();
        }
    }
}
