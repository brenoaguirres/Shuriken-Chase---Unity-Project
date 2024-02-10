using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody2D;
    protected Animator _animator;
    private BasicMovement _basicMovement;
    public bool _canFall = false;
    [SerializeField] protected float _fallSpeed = 10f;
    public bool _isAlive = true;

    private void Start() {
        _animator = GetComponent<Animator>();
        _basicMovement = GetComponent<BasicMovement>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        if (_canFall) {
            Fall();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag != "Projectile") {
            GetComponent<PlayerStateMachine>().StartDeathState();
            Death();
        }
    }

    protected void Death() {
        if (this.gameObject.tag == "Player") {
            BroadcastMessage("SFXDeath");
        }
        _animator.SetTrigger("Death");
        GetComponent<Collider2D>().isTrigger = true;
        _rigidbody2D.velocity = Vector2.zero; // fix glitch - moving forwards
        _basicMovement.enabled = false;
        _canFall = true;
        _isAlive = false;
        
    }

    private void Fall() {
        _rigidbody2D.AddForce(Vector2.down * _fallSpeed, ForceMode2D.Force);
    }
}
