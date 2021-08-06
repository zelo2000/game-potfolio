using Assets.Scripts.Enums;
using Assets.Scripts.Models;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Properties")]
    public float StartSpeed = 10f;
    public float StartHealth = 100f;
    public int Bounty = 50;
    public GameObject DeathEffect;

    [Header("Unity setup")]
    public Image HealthBar;
    public Canvas HealthCanvas;

    [HideInInspector]
    public float Speed;
    [HideInInspector]
    public float Health;

    private List<Debuff> _debuffs;
    private bool _isDead;

    //
    // Custom Functions
    //
    public void TakeDamage(float amount)
    {
        Health -= amount;

        HealthBar.fillAmount = Health / StartHealth;

        if (Health <= 0 && !_isDead)
        {
            Die();
        }
    }

    public void AddDebuff(Debuff debuff)
    {
        debuff.StartTime = Time.time;
        if (_debuffs.Any(d => d.Type == debuff.Type))
        {
            _debuffs.RemoveAll(d => d.Type == debuff.Type);
            _debuffs.Add(debuff);

            if (debuff.Type == DebuffType.Freezing)
            {
                Speed = StartSpeed * (1f - debuff.Value);
            }
        }
        else
        {
            _debuffs.Add(debuff);
        }
    }

    public void RemoveDebuff(Debuff debuff)
    {
        var debuffLocal = _debuffs.FirstOrDefault(d => d.Type == debuff.Type);
        if (debuff.Type == DebuffType.Freezing)
        {
            Speed = StartSpeed;
        }
        _debuffs.Remove(debuffLocal);
    }

    private void Die()
    {
        _isDead = true;

        PlayerStats.Instanse.IncreaseMoney(Bounty);

        var impactEffect = Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(impactEffect, 5f);

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }

    //
    // Unity Functions
    //
    private void Start()
    {
        Speed = StartSpeed;
        Health = StartHealth;
        _debuffs = new List<Debuff>();
    }

    private void Update()
    {
        if (GameMaster.IsHealthShown)
        {
            HealthCanvas.enabled = true;
        }
        else
        {
            HealthCanvas.enabled = false;
        }

        var expiredDebuffs = _debuffs.Where(d => Time.time >= d.StartTime + d.Duration).ToList();
        foreach (var debuff in expiredDebuffs)
        {
            RemoveDebuff(debuff);
        }
    }
}
