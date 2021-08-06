using Assets.Scripts.Helpers;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats")]
    private static int _money;
    public int StartMoney = 400;

    private static int _lives;
    public int StartLives = 20;

    public static int Rounds;

    [Header("Unity Setup")]
    public Text LivesText;
    public Text MoneyText;

    public static PlayerStats Instanse { get; private set; }

    public void ReduceLives(int amount = 1)
    {
        _lives -= amount;
        LivesText.text = _lives.ToString();
    }
    public void IncreaseLives(int amount = 1)
    {
        _lives += amount;
        LivesText.text = _lives.ToString();
    }
    public int GetLives()
    {
        return _lives;
    }

    public void ReduceMoney(int amount = 1)
    {
        _money -= amount;
        MoneyText.text = MoneyHelper.AddHryvnyaSign(_money);
    }
    public void IncreaseMoney(int amount = 1)
    {
        _money += amount;
        MoneyText.text = MoneyHelper.AddHryvnyaSign(_money);
    }
    public int GetMoney()
    {
        return _money;
    }

    //
    // Unity Functions
    //
    private void Start()
    {
        _money = StartMoney;

        _lives = StartLives;
        LivesText.text = _lives.ToString();
        MoneyText.text = MoneyHelper.AddHryvnyaSign(_money);

        Rounds = 0;
    }

    private void Awake()
    {
        if (Instanse != null)
        {
            Debug.LogError("More than one Player Stats at the scene!");
            return;
        }

        Instanse = this;
    }
}
