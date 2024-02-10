using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : BasicMovement
{
    
    [SerializeField] private float _moveSpeed = 3;

    void Start()
    {
        
    }

    void Update()
    {
        MovementLogic();
    }

    protected override void MovementLogic() {
        transform.Translate(Vector2.left * _moveSpeed * Time.deltaTime);
    }
}
