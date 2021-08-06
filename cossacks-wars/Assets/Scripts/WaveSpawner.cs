using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public GameMaster GameMaster;

    public List<Wave> Waves;

    public Transform spawnPoint;
    public float TimeBetweenWaves = 3f;
    public Text WaveCountdownText;

    public static int EnemiesAlive = 0;

    private float _countDown = 2f;
    private int _waveIndex = 0;

    //
    // Custom Functions
    //
    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        var wave = Waves[_waveIndex];
        EnemiesAlive = wave.Count;
        for (int i = 0; i < wave.Count; i++)
        {
            SpawnEnemy(wave.Enemy);
            yield return new WaitForSeconds(1 / wave.SpawnRate);
        }

        _waveIndex++;
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    //
    // Unity Functions
    //
    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (_waveIndex == Waves.Count)
        {
            GameMaster.WinLevel();
            enabled = false;
        }

        if (_countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countDown = TimeBetweenWaves;
            return;
        }

        _countDown -= Time.deltaTime;
        _countDown = Mathf.Clamp(_countDown, 0f, Mathf.Infinity);

        WaveCountdownText.text = $"{_countDown:0.00}";
    }
}
