using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColShuriken : Collectible
{
    private void OnCollect(Collider2D col) {
        CollectibleReceiver cr = col.GetComponent<CollectibleReceiver>();
        if (cr != null) {
            cr.AddItem(this, _quantityToAdd);
        }
    }
}
