using System.Linq;
using UnityEngine;

public class SpawnTear : MonoBehaviour
{
    public float SpawnRate;
    public GameObject Tear;
    public string Tag;

    private GameObject _target;
    private float _nextFireTime;

    void Update()
    {
        _target = GameObject.FindGameObjectsWithTag(Tag).ToList().FirstOrDefault();
        if (Time.time > _nextFireTime && _target != null)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        _nextFireTime = Time.time + SpawnRate;
        transform.position = new Vector3(_target.transform.position.x, transform.position.y, transform.position.z);
        Instantiate(Tear, transform.position, Quaternion.identity);
    }
}
