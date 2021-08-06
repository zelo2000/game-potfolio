using UnityEngine;

public class Tear : MonoBehaviour
{
    public float Speed = 5;

    private float TimeToChangeColorBack;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = -transform.up * Speed;//new Vector2(-0.4f * Speed, -0.4f * Speed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "Boss" || other.collider.name == "Sky") { return; }

        if (other.collider.name == "Player")
        {
            var playerMovement = other.collider.GetComponentInChildren<PlayerMovement>();
            var renderer = other.collider.GetComponentInChildren<SpriteRenderer>();
            renderer.color = Color.red;
            playerMovement.TimeToChangeColorBack = Time.time + 1f;

            Stats.Instanse.ReducePlayerLives(1);
        }

        Destroy(gameObject);
    }

    private void Update()
    {
        if (transform.position.x > 500 || transform.position.x < -500 || transform.position.y > 500 || transform.position.y < -500)
        {
            Destroy(gameObject);
        }
    }
}
