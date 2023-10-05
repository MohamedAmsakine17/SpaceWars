using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    SpawnManager _spawnManager;
    WayConfigSO _wayConfigSO;
    List<Transform> _wayPoints;
    int _wayPointIndex = 0;

    void Awake()
    {
        _spawnManager = FindObjectOfType<SpawnManager>();
    }

    void Start()
    {
        _wayConfigSO = _spawnManager.GetCurrentWave();
        _wayPoints = _wayConfigSO.GetWayPoints();
        transform.position = _wayPoints[_wayPointIndex].position;
    }

    void Update()
    {
        if (_wayPointIndex < _wayPoints.Count)
        {
            Vector3 nextWayPoint = _wayPoints[_wayPointIndex].position;
            float deltaSpeed = _wayConfigSO.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, nextWayPoint, deltaSpeed);
            if (transform.position == nextWayPoint)
                _wayPointIndex++;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
