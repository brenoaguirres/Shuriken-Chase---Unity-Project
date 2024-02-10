using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : HealthController
{
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag != "EnemyProjectile" && other.gameObject.tag != "Player" && other.gameObject.tag != "Enemy") {
            BroadcastMessage("SFXHurt");
            Death();
            BroadcastMessage("SetScore");
        }
    }
}
