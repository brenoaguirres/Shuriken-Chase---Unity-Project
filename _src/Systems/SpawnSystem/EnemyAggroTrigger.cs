using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggroTrigger : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.tag == "Enemy")
        {
            BasicCharacterAttack _throwAttack;
            if (col.TryGetComponent<BasicCharacterAttack>(out _throwAttack))
            {
                _throwAttack.enabled = true;
            }
            col.GetComponent<HealthController>().enabled = true;
        }    
    }
}
