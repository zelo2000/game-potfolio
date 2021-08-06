using UnityEngine;

[RequireComponent(typeof(Boss))]
public class SociofobyBoss : MonoBehaviour
{
    public GameObject SpawnPoint;

    private Boss _boss;

    public void SpawnEnemies()
    {
        SpawnPoint.SetActive(true);
        Debug.Log("Spawn");
    }

    // Start is called before the first frame update
    void Start()
    {
        _boss = GetComponent<Boss>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
