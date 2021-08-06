using UnityEngine;

[RequireComponent(typeof(Boss))]
public class ApathyBoss : MonoBehaviour
{
    private Boss _boss;

    public GameObject WaveSpawnerPoint;
    public GameObject WaveDamageEffect;

    public GameObject TearSpawnPoint;

    public void WaveDamage()
    {
        Instantiate(WaveDamageEffect, WaveSpawnerPoint.transform.position, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        _boss = GetComponent<Boss>();
        TearSpawnPoint.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (_boss.Phase > 1)
        {
            TearSpawnPoint.SetActive(false);
        }
    }
}
