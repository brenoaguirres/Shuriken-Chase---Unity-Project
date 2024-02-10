using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableObject : MonoBehaviour
{
    private bool _isCurrentlyInUse = false;
    protected Vector3 _initialPos;

    private void Start() {
        _initialPos = transform.position;
    }

    void Update()
    {
        CheckIfSpawned();
    }

    private void CheckIfSpawned() {
        if (transform.position == _initialPos) {
            _isCurrentlyInUse = false;
        }
        else {
            _isCurrentlyInUse = true;
        }
    }

    public bool IsCurrrentlyInUse() {
        return _isCurrentlyInUse;
    }

    public void ResetObject() {
        GetComponent<HealthController>()._isAlive = true;
        GetComponent<HealthController>()._canFall = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Collider2D>().isTrigger = false;
        GetComponent<BasicMovement>().enabled = false;
        transform.position = _initialPos;
        BasicCharacterAttack _charAtk;
        if (TryGetComponent(out _charAtk))
        {
            _charAtk.enabled = false;
        }
    }
}
