using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCharacterAttack : MonoBehaviour
{
    protected Animator _animator;
    [SerializeField] protected Transform[] _projectilesTransform = {};
    [SerializeField] protected int _currentProjectile = 0;
    [SerializeField] protected Transform _throwPosition;
    [SerializeField] protected float _attackRate = 0.5f;
    protected bool _canShoot = true;

    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Throw_Projectile() {
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

    protected IEnumerator LockAttack() {
        _canShoot = false;
        yield return new WaitForSeconds(_attackRate);
        _canShoot = true;
    }

    // Animation Related Functions
    
    protected void TriggerThrowAnim() {
        if (this.gameObject.tag == "Player") {
            BroadcastMessage("SFXAttack");
        }
        _animator.SetTrigger("Throw");
    }

}
