using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    protected Vector3 _initialPos;
    protected Rigidbody2D _rigidbody2d;
    [SerializeField]
    protected float _moveSpeed = 5f;

    void Start()
    {
        _initialPos = GetComponent<Transform>().position;
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position != _initialPos) {
            transform.Translate(Vector2.left * _moveSpeed * Time.deltaTime);
        }

        if (transform.position.x <= -20f) {
            _rigidbody2d.velocity = Vector2.zero;
            transform.position = _initialPos;
        }

        if (transform.position.y <= -7.5f) {
            _rigidbody2d.velocity = Vector2.zero;
            transform.position = _initialPos;           
        }
    }
}
