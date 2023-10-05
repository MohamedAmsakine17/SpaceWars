using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    FireShoot _fireShoot;

    [SerializeField] float _moveSpeed = 15f;

    [Header("Paddings")]
    [SerializeField] float _paddingRight;
    [SerializeField] float _paddingLeft;
    [SerializeField] float _paddingTop;
    [SerializeField] float _paddingBottom;

    Vector2 _moveInput;
    Vector2 _minBounds;
    Vector2 _maxBounds;


    void Awake()
    {
        _fireShoot = GetComponent<FireShoot>();
    }

    void Start()
    {
        InitBounds();
    }

    void Update()
    {

        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        _minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        _maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    void Move()
    {
        Vector3 movePosition = _moveInput * _moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + movePosition.x, _minBounds.x + _paddingLeft, _maxBounds.x - _paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + movePosition.y, _minBounds.y + _paddingBottom, _maxBounds.y - _paddingTop);
        transform.position = newPos;
    }

    void OnFire(InputValue value)
    {
        if (_fireShoot != null)
        {
            _fireShoot._isFireing = value.isPressed;
        }
    }
}
