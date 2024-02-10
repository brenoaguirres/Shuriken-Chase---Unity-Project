using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectResetter : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.tag == "Crate") {
            col.GetComponent<SpawnableCrate>().ResetObject();
            return;           
        }

        if (col.tag != "EnemyProjectile" && col.tag != "Projectile") {
            col.GetComponent<SpawnableObject>().ResetObject();
        }

        if (col.tag == "EnemyProjectile" || col.tag == "Projectile" ) {
            if (col.GetComponent<ProjectileHealth>()._isAlive == false) {
                col.GetComponent<ProjectileHealth>().ResetObject();
            }
        }
    }
}
