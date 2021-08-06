using Assets.Scripts.Constants;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public int LevelToUnlock = 2;

    public GameObject GameOverUI;
    public GameObject WonLevelUI;

    public static bool GameIsOver;
    public static bool IsHealthShown;

    //
    // Custom Functions
    //
    private void EndGame()
    {
        GameIsOver = true;
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void WinLevel()
    {
        GameIsOver = true;
        WonLevelUI.SetActive(true);

        if (PlayerPrefs.GetInt(PlayerPrefsKeys.LevelReached) < LevelToUnlock)
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.LevelReached, LevelToUnlock);
        }
    }

    //
    // Unity Functions
    //
    private void Start()
    {
        GameIsOver = false;
        IsHealthShown = true;
    }

    void Update()
    {
        if (GameIsOver)
        {
            return;
        }

        if (Stats.Instanse.GetPlayerLives() <= 0)
        {
            EndGame();
        }

        if (Stats.Instanse.GetBossHP() <= 0)
        {
            WinLevel();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            IsHealthShown = !IsHealthShown;
        }
    }
}
