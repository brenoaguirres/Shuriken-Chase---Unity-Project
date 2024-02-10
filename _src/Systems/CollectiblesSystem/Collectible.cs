using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] protected int _quantityToAdd = 0;

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            OnCollect(col);
        }
    }

    private void OnCollect(Collider2D col) {
        Debug.Log("Not implemented call to OnCollect()");
    }

    public int GetQuantityToAdd() {
        return _quantityToAdd;
    }
}
