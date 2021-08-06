using UnityEngine;

public class WaveBossDamage : MonoBehaviour
{
    public float Speed = 5f;

    // Update is called once per frame
    void Update()
    {
        var position = transform.position;
        position.x -= Speed * Time.deltaTime;
        transform.position = position;

        if (transform.position.x > 15 || transform.position.x < -15 || transform.position.y > 15 || transform.position.y < -15)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            Stats.Instanse.ReducePlayerLives();
        }
    }
}
