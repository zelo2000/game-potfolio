using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    private JoystickBehavior joystick;
    private BoltSpawner boltSpawner;
    private float lastShootTime;
    public float ShootInterval;
    public float Speed;
    public float XRange;
    // Use this for initialization
    void Start()
    {
        joystick = FindObjectOfType<JoystickBehavior>();
        boltSpawner = FindObjectOfType<BoltSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    private void Shoot()
    {
        if (Time.time-lastShootTime> ShootInterval)
        {
            lastShootTime = Time.time;
            boltSpawner.Shoot();
        }
    }

    private void Move()
    {
        var position = transform.position;
        position.x += joystick.DeltaXDrag * Speed;
        position.x = Mathf.Clamp(position.x, -XRange, XRange);
        transform.position = position;
    }
}
