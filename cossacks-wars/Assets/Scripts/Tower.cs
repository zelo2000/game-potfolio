using Assets.Scripts.Enums;
using Assets.Scripts.Models;
using UnityEngine;

// Go and update <see cref="TowerCustomEditor"/> after you add new field here.
public class Tower : MonoBehaviour
{
    public float Range = 15f;
    public float TurnSpeed = 10f;

    public string EnemyTag = "Enemy";
    public Transform PartToRotate;
    public Transform FirePoint;

    public TowerShellType Type = TowerShellType.Bullet;
    #region Bullets Setup
    public float FireRate = 1f;
    public GameObject BulletPrefab;
    #endregion
    #region Laser Setup
    public int DamageOverTime = 30;
    public Debuff Debuff;
    public LineRenderer LineRenderer;
    public ParticleSystem ImpactEffect;
    public Light ImpactLight;
    #endregion

    private float _fireCountdown = 0f;
    private Transform _target;
    private Enemy _enemy;

    //
    // Custom Functions
    //
    void Shoot()
    {
        var bulletGameObject = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        var bullet = bulletGameObject.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(_target);
        }
    }

    private void UpdateTarget()
    {
        var enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
        var shortesDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (var enemy in enemies)
        {
            var distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortesDistance)
            {
                shortesDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortesDistance <= Range)
        {
            _target = nearestEnemy.transform;
            _enemy = _target.GetComponent<Enemy>();
        }
        else
        {
            _target = null;
        }
    }

    private void LockOnTarget()
    {
        var direction = _target.position - transform.position;
        var lookRotation = Quaternion.LookRotation(direction);
        var rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * TurnSpeed).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void Laser()
    {
        _enemy.TakeDamage(DamageOverTime * Time.deltaTime);
        _enemy.AddDebuff(Debuff);

        if (!LineRenderer.enabled)
        {
            LineRenderer.enabled = true;
            ImpactLight.enabled = true;
            ImpactEffect.Play();
        }

        LineRenderer.SetPositions(new Vector3[] { FirePoint.position, _target.position });

        var direction = FirePoint.position - _target.position;
        ImpactEffect.transform.position = _target.position + direction.normalized;

        ImpactEffect.transform.rotation = Quaternion.LookRotation(direction);
    }

    //
    // Unity Functions
    //
    void Start()
    {
        InvokeRepeating(nameof(UpdateTarget), 0f, 0.5f);
    }

    void Update()
    {
        if (_target == null)
        {
            if (Type == TowerShellType.Laser)
            {
                if (LineRenderer.enabled)
                {
                    LineRenderer.enabled = false;
                    ImpactLight.enabled = false;
                    ImpactEffect.Stop();
                }
            }

            return;
        }

        LockOnTarget();

        if (Type == TowerShellType.Laser)
        {
            Laser();
        }
        else
        {
            // Stuff for fire
            if (_fireCountdown <= 0f)
            {
                Shoot();
                _fireCountdown = 1f / FireRate;
            }

            _fireCountdown -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
