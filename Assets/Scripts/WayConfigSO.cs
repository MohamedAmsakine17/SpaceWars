using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Way Confing", menuName = "Way Config")]
public class WayConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> _enemiesPrefab;
    [SerializeField] Transform _pathTransform;
    [SerializeField] float _moveSpeed = 5f;

    [Header("Spawn")]
    [SerializeField] float _timeBetweenEnemySpawn;
    [SerializeField] float _spawnTimeVariance;
    [SerializeField] float _minSpawnTime;


    public Transform GetStartingWayPoint()
    {
        return _pathTransform.GetChild(0);
    }

    public List<Transform> GetWayPoints()
    {
        List<Transform> wayPoints = new List<Transform>();
        foreach (Transform wayPoint in _pathTransform)
        {
            wayPoints.Add(wayPoint);
        }
        return wayPoints;
    }

    public float GetMoveSpeed()
    {
        return _moveSpeed;
    }

    public int GetEnemyCount()
    {
        return _enemiesPrefab.Count;
    }

    public GameObject GetEnemyPrefab(int EnemyIndex)
    {
        return _enemiesPrefab[EnemyIndex];
    }

    public float GetRandomSpawnPoint()
    {
        float spawnTime = Random.Range(_timeBetweenEnemySpawn - _spawnTimeVariance,_timeBetweenEnemySpawn+_spawnTimeVariance);
        return Mathf.Clamp(spawnTime,_minSpawnTime,float.MaxValue);
    }
}
