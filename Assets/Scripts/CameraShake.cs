using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float _shakeDuration = 1f;
    [SerializeField] float _shakeMagnitude = 0.5f;

    Vector3 _initialPosition;
    void Start()
    {
        _initialPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float timer = 0;
        while (timer < _shakeDuration)
        {
            transform.position = _initialPosition + (Vector3)Random.insideUnitCircle * _shakeMagnitude;
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = _initialPosition;
    }
}
