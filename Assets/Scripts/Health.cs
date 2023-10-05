using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    CameraShake _cameraShake;
    AudioPlayer _audioPlayer;
    ScoreKeeper _scoreKeeper;
    LevelManager _levelManager;

    [Header("General")]
    [SerializeField] bool _isPlayer;

    [Header("Health")]
    [SerializeField] float _health = 50f;
    [SerializeField] ParticleSystem _explosionEffect;

    [Header("Score")]
    [SerializeField] int _score = 50;

    [Header("Camera")]
    [SerializeField] bool _shakeCamera;


    void Awake()
    {
        _cameraShake = Camera.main.GetComponent<CameraShake>();
        _audioPlayer = FindObjectOfType<AudioPlayer>();
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        _levelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer _damageDealer = other.GetComponent<DamageDealer>();
        if (_damageDealer != null)
        {
            TakeDamage(_damageDealer.GetDamage());
            ExpolsionEffect();
            _audioPlayer.PlayDamageClip();
            ShakingCamera();
            _damageDealer.Hit();
        }
    }

    void TakeDamage(float damage)
    {
        Debug.Log(gameObject.name);
        _health -= damage;
        if (_health <= 0)
            Die();
    }

    void Die()
    {
        if (!_isPlayer)
        {
            _scoreKeeper.ChangeScore(_score);
        }
        else
        {
            _levelManager.loadScene("GameOver");
        }
        Destroy(gameObject);

    }

    void ExpolsionEffect()
    {
        ParticleSystem instance = Instantiate(_explosionEffect, transform.position, Quaternion.identity);
        Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
    }

    void ShakingCamera()
    {
        if (_cameraShake != null && _shakeCamera)
        {
            _cameraShake.Play();
        }
    }

    public float GetHealth()
    {
        return _health;
    }
}
