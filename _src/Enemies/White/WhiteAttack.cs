using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteAttack : BasicCharacterAttack
{
    void Update()
    {
        if (_canShoot) {
            TriggerThrowAnim();
            _projectilesTransform[_currentProjectile].position = _throwPosition.position;

            if (_currentProjectile < _projectilesTransform.Length - 1) {
                _currentProjectile += 1;
            }
            else {
                _currentProjectile = 0;
            }

            StartCoroutine(LockAttack());
        }
    }
}
