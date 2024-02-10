using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private bool _canAttack = true;
    [SerializeField] private Transform _playerTransform;
    private Animator _animator;
    [SerializeField] protected float _attackRate = 0.5f;
    [SerializeField] protected float _attackDistance = 1f;

    private void Start() {
        _animator = GetComponent<Animator>();        
    }

    private void Update() {
        if (_canAttack && CheckPlayerWithinDistance()) {
            TriggerAttackAnim();
            LockAttack();
        }
    }

    private bool CheckPlayerWithinDistance() {
        float distanceToPlayer = Vector3.Distance(transform.position, _playerTransform.position);
        if (distanceToPlayer <= _attackDistance) {
            return true;
        }
        return false;
    }

    private void TriggerAttackAnim() {
        _animator.SetTrigger("Attack");
    }

    protected IEnumerator LockAttack() {
        _canAttack = false;
        yield return new WaitForSeconds(_attackRate);
        _canAttack = true;
    }
}
