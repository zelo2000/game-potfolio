using Assets.Scripts.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    public string LevelToLoad;
    public int LevelIndex;

    private void Start()
    {
        var levelReached = PlayerPrefs.GetInt(PlayerPrefsKeys.LevelReached, 1);
        if (levelReached < LevelIndex)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f);
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnMouseDown()
    {
        var levelReached = PlayerPrefs.GetInt(PlayerPrefsKeys.LevelReached, 1);
        if (levelReached >= LevelIndex)
        {
            SceneManager.LoadScene(LevelToLoad);
        }
    }
}
