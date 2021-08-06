using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public List<GameObject> EnemyPrefabs;
    public float SpawnInterval;
    public float RangeX;
    public float SpeedProgression;
    private IEnumerator Start()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(SpawnInterval);
        }
    }

    private void Spawn()
    {
        var enemy = Instantiate(EnemyPrefabs[Random.Range(0, EnemyPrefabs.Count)]);
        var position = transform.position;
        position.x = Random.Range(-RangeX, RangeX);
        enemy.transform.position = position;
        var velocity = enemy.GetComponent<Mover>().Velocity;
        velocity.x = Random.Range(-2.0f, 2.0f);
        velocity *= Random.Range(1.0f, 2.0f) * (1.0f + SpeedProgression * Time.time);
    }
}
