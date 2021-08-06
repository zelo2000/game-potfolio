using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    private static int _playerLives;
    public HealthBar _playerHealthBar;
    public int StartPlayerLives = 3;

    private static int _bossHealhPoints;
    public HealthBar _bossHealthBar;
    public int StartBossHealthPoints = 200;

    public static Stats Instanse { get; private set; }

    public void ReducePlayerLives(int amount = 1)
    {
        _playerLives -= amount;
        _playerHealthBar.SetHealth(_playerLives);
    }
    public void IncreasePlayerLives(int amount = 1)
    {
        _playerLives += amount;
        _playerLives = _playerLives > StartPlayerLives ? StartPlayerLives : _playerLives;
        
        _playerHealthBar.SetHealth(_playerLives);
    }
    public int GetPlayerLives() => _playerLives;

    public void ReduceBoosHP(int amount = 1)
    {
        _bossHealhPoints -= amount;
        _bossHealthBar.SetHealth(_bossHealhPoints);
    }
    public void IncreaseBossHP(int amount = 1)
    {
        _bossHealhPoints += amount;
        _bossHealhPoints = _bossHealhPoints > StartBossHealthPoints ? StartBossHealthPoints : _bossHealhPoints;
        
        _bossHealthBar.SetHealth(_bossHealhPoints);
    }
    public int GetBossHP() => _bossHealhPoints;

    private void Start()
    {
        _playerLives = StartPlayerLives;
        _playerHealthBar.SetMaxHealth(_playerLives);
        _bossHealhPoints = StartBossHealthPoints;
        _bossHealthBar.SetMaxHealth(_bossHealhPoints);
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

