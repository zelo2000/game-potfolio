using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerShots : MonoBehaviour
{
    public GameObject Bullet;
    public Transform FirePoint;
    public float FireRate;

    private float _nextFireTime;
    private PlayerMovement _playerMovement;

    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Time.time > _nextFireTime)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Shoot(0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                Shoot(-90);
                if (!_playerMovement.FacingRight)
                {
                    _playerMovement.Flip();
                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                Shoot(90);
                if (_playerMovement.FacingRight)
                {
                    _playerMovement.Flip();
                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Shoot(180);
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                Shoot(45);
                if (_playerMovement.FacingRight)
                {
                    _playerMovement.Flip();
                }
            }
            else if (Input.GetKey(KeyCode.E))
            {
                Shoot(-45);
                if (!_playerMovement.FacingRight)
                {
                    _playerMovement.Flip();
                }
            }
        }
    }

    void Shoot(int angle)
    {
        _nextFireTime = Time.time + FireRate;
        Instantiate(Bullet, FirePoint.position, Quaternion.Euler(0, 0, angle));
    }
}
