using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltSpawner : MonoBehaviour {
    public GameObject BoltPrefab;
    public void Shoot()
    {
        Instantiate(BoltPrefab, transform.position,transform.rotation);
    }
}
