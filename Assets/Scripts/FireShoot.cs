using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShoot : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] float _projectileSpeed = 10f;
    [SerializeField] float _projectileLifeTime = 5f;
    [SerializeField] float _firingRate = 2f;
    [Header("AI")]
    [SerializeField] bool _useAI = false;
    [SerializeField] float _firingTimeVariance = 0f;
    [SerializeField] float _firingMinTime = 0.2f;

    [HideInInspector] public bool _isFireing;

    Coroutine _shootingCoroutine;
    AudioPlayer _audioPlayer;

    void Awake()
    {
        _audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if (_useAI)
            _isFireing = true;
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (_isFireing && _shootingCoroutine == null)
        {
            _shootingCoroutine = StartCoroutine(ShootingCoroutine());
        }

        else if (!_isFireing && _shootingCoroutine != null)
        {
            StopCoroutine(_shootingCoroutine);
            _shootingCoroutine = null;
        }

    }

    IEnumerator ShootingCoroutine()
    {
        while (true)
        {
            GameObject projectTile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D projectTileRb2D = projectTile.GetComponent<Rigidbody2D>();
            if (projectTileRb2D != null)
            {
                projectTileRb2D.velocity = transform.up * _projectileSpeed;
            }
            Destroy(projectTile, _projectileLifeTime);
            float timeBettwenShooting = Random.Range(_firingRate - _firingTimeVariance, _firingRate + _firingTimeVariance);
            timeBettwenShooting = Mathf.Clamp(timeBettwenShooting, _firingMinTime, float.MaxValue);
            _audioPlayer.PlayShootingClip();
            yield return new WaitForSeconds(timeBettwenShooting);
        }
    }
}
