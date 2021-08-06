using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Physics Setup")]
    public float Speed = 70f;
    public int Damage = 50;
    public float ExplosionRadius = 0f;
    public GameObject ImpactEffect;

    [Header("Enemy Setup")]
    public string EnemyTag = "Enemy";

    private Transform _target;

    //
    // Custom Functions
    //
    public void Seek(Transform target)
    {
        _target = target;
    }

    void HitTarget()
    {
        var impactEffect = Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(impactEffect, 5f);

        if (ExplosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            DamageEnemy(_target);
        }

        Destroy(gameObject);
    }

    void Explode()
    {
        var hitObjects = Physics.OverlapSphere(transform.position, ExplosionRadius);

        foreach (var hitObject in hitObjects)
        {
            if (hitObject.CompareTag(EnemyTag))
            {
                DamageEnemy(hitObject.transform);
            }
        }
    }

    void DamageEnemy(Transform enemy)
    {
        var enemyScript = enemy.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.TakeDamage(Damage);
        }
    }

    //
    // Unity Functions
    //
    void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        var direction = _target.position - transform.position;
        float distanceThisFrame = Speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(_target);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
    }
}
