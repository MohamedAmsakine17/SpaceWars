using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    //AudioPlayer instance;

    [Header("Shooting")]
    [SerializeField] AudioClip _shootingClip;
    [SerializeField][Range(0f, 1f)] float _shootingVolume;

    [Header("Damage")]
    [SerializeField] AudioClip _damageClip;
    [SerializeField][Range(0f, 1f)] float _damageVolume = 1f;

    void Awake()
    {
        int instance = FindObjectsOfType<AudioPlayer>().Length;
        if (instance > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayClip(_shootingClip, _shootingVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(_damageClip, _damageVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
