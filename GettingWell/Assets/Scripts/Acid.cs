using System.Collections;
using UnityEngine;

public class Acid : MonoBehaviour
{
    private Stats _stats;
    public static bool IsWithPlayer;

    private void Start()
    {
        _stats = Stats.Instanse;
        IsWithPlayer = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            IsWithPlayer = true;
            StartCoroutine(ReduceHealth());
        }
    }

    IEnumerator ReduceHealth()
    {
        while (IsWithPlayer)
        {
            Stats.Instanse.ReducePlayerLives(1);
            yield return new WaitForSecondsRealtime(1f);
        }

        yield return new WaitForSecondsRealtime(0);
    }
}
