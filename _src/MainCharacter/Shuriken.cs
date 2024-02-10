using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : BasicProjectile
{
    void Update()
    {
        if (transform.position != _initialPos) {
            transform.Translate(Vector2.right * _moveSpeed * Time.deltaTime);
        }

        if (transform.position.x >= 2.5f) {
            _rigidbody2d.velocity = Vector2.zero;
            transform.position = _initialPos;
        }
    }
}
