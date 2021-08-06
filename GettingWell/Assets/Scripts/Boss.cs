using System.Collections;
using Assets.Scripts.Constants;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject DeathEffect;

    [HideInInspector]
    public int Phase = 1;

    private Stats _stats;
    private Animator _animator;
    private SpriteRenderer _renderer;

    public void TakeDamage(int damage)
    {
        StartCoroutine(SwitchColor());

        _stats.ReduceBoosHP(damage);

        if (_stats.GetBossHP() <= _stats.StartBossHealthPoints / 2)
        {
            Phase++;
            _animator.SetInteger(BossPhaseAnimation.Phase, Phase);
        }

        if (_stats.GetBossHP() <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _stats = Stats.Instanse;
        _animator = GetComponent<Animator>();
        _animator.SetInteger(BossPhaseAnimation.Phase, Phase);
    }

    private IEnumerator SwitchColor()
    {
        var material = _renderer.material;

        material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        material.color = Color.white;
    }
}
