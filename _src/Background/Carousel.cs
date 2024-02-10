using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carousel : MonoBehaviour
{
    private Vector2 _initialPos;
    private float _xSize;
    private float _displacement;
    [SerializeField]
    private float _moveSpeed = 0.5f;

    
    void Start()
    {
        _initialPos = transform.position;
        _xSize = GetComponent<SpriteRenderer>().bounds.size.x;
        _displacement = 0.0f;
    }

    void Update()
    {
        _displacement = transform.position.x - _initialPos.x;
        if (_displacement <= -_xSize) {
            transform.position = _initialPos;
        }

        transform.Translate(Vector2.left * _moveSpeed * Time.deltaTime);
    }
}
