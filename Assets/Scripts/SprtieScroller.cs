using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprtieScroller : MonoBehaviour
{
    [SerializeField] Vector2 _moveSpeed;

    Vector2 _offset;
    Material _spriteMatrial;

    void Awake()
    {
        _spriteMatrial = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        _offset += _moveSpeed * Time.deltaTime;
        _spriteMatrial.mainTextureOffset = _offset;
    }
}
