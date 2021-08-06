using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControler : MonoBehaviour
{
    public int Score = 0;
    public Text ScoreText;

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void AddScore()
    {
        Score += 10;
        ScoreText.text = Score.ToString();
    }
}
