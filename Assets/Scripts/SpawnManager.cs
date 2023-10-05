using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<WayConfigSO> _wavesList;
    [SerializeField] float _timeBettwenWaves = 0f;
    [SerializeField] bool _isLooping = true;
    WayConfigSO _currentWave;




    void Start()
    {
        StartCoroutine(SpawnEnemies());

    }

    IEnumerator SpawnEnemies()
    {
        do
        {
            foreach (WayConfigSO wave in _wavesList)
            {
                _currentWave = wave;
                for (int i = 0; i < _currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(_currentWave.GetEnemyPrefab(i), _currentWave.GetStartingWayPoint().position, Quaternion.Euler(0, 0, 180), transform);
                    yield return new WaitForSeconds(_currentWave.GetRandomSpawnPoint());
                }
                yield return new WaitForSeconds(_timeBettwenWaves);
            }
        } while (_isLooping);
    }

    public WayConfigSO GetCurrentWave()
    {
        return _currentWave;
    }
}
