using Assets.Scripts.Constants;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public List<Button> LevelButtons;

    //
    // Custom Functions
    //
    public void Select(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    //
    // Unity Functions
    //
    private void Start()
    {
        // TODO: Change level unlocking
        var levelReached = PlayerPrefs.GetInt(PlayerPrefsKeys.LevelReached, 1);

        for (int i = 0; i < LevelButtons.Count; i++)
        {
            if (i + 1 > levelReached)
            {
                LevelButtons[i].interactable = false;
            }
        }
    }
}
