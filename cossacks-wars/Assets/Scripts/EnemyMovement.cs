using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform _target;
    private Enemy _enemy;
    private int _wayPointIndex = 0;

    //
    // Custom Functions
    //
    void GetNextWaypoint()
    {
        if (_wayPointIndex >= WayPoints.Points.Length - 1)
        {
            EndPath();
            return;
        }

        _wayPointIndex++;
        _target = WayPoints.Points[_wayPointIndex];
    }

    void EndPath()
    {
        PlayerStats.Instanse.ReduceLives();
        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }

    //
    // Unity Functions
    //
    void Start()
    {
        _enemy = GetComponent<Enemy>();
        _target = WayPoints.Points[_wayPointIndex];
    }

    void Update()
    {
        var direction = _target.position - transform.position;
        transform.Translate(direction.normalized * _enemy.Speed * Time.deltaTime, Space.World);


        if (Vector3.Distance(transform.position, _target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }
}
