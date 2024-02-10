using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHealth : HealthController
{
    protected BasicProjectile _projectile;

    
    private void Start() {
        _animator = GetComponent<Animator>();
        _projectile = GetComponent<BasicProjectile>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (this.tag == "EnemyProjectile") {
            BroadcastMessage("SetScore");
        }
        Death();
    }

    protected new void Death() {
        _animator.enabled = false;
        GetComponent<Collider2D>().isTrigger = true;
        _rigidbody2D.velocity = Vector2.zero; // fix glitch - moving forwards
        _projectile.enabled = false;
        _canFall = true;
        _isAlive = false;
    }

    public void ResetObject() {
        _animator.enabled = true;
        GetComponent<Collider2D>().isTrigger = false;
        _projectile.enabled = true;
        _canFall = false;
        _isAlive = true;
        _rigidbody2D.velocity = Vector2.zero;
    }
}
