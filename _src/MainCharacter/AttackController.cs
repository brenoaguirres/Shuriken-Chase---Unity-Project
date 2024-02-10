using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : BasicCharacterAttack
{
    protected bool _hasAmmo = true;
    [SerializeField] private Ammunition _ammunition;
    [SerializeField] private PlayerStateMachine _playerStateMachine;

    private void Throw_Projectile() {
        CheckAmmo();
        if (_canShoot && _hasAmmo) {
            _playerStateMachine.StartAttackState();
            BroadcastMessage("SpendAmmo");
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
        if (_playerStateMachine.GetAttackState()) {
            StartCoroutine(_playerStateMachine.WaitAttackState());
        }
    }

    private void CheckAmmo() {
        if (_ammunition.GetAmmoCount() == 0)
        {
            _hasAmmo = false;
        }
    }
}
