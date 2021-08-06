using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 5f;
    public int Damage = 10;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = transform.up * Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player") { return; }

        var boss = collision.GetComponent<Boss>();
        if (boss != null)
        {
            boss.TakeDamage(Damage);
        }

        Destroy(gameObject);
    }

    private void Update()
    {
        if (transform.position.x > 15 || transform.position.x < -15 || transform.position.y > 15 || transform.position.y < -15)
        {
            Destroy(gameObject);
        }
    }
}
