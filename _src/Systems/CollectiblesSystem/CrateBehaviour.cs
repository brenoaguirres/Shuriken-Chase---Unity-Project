using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateBehaviour : MonoBehaviour
{
    [SerializeField] Collectible[] _availableCollectibles;
    [SerializeField] float[] _dropRates;
    [SerializeField] Ammunition _playerAmmo;
    private Collectible _selectedCollectible;
    [SerializeField] CollectibleReceiver _collectibleReceiver;

    private void Start() {
        DisableCrate();
        RandomizeCollectible();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Projectile" || col.tag == "Player") {
            if (_collectibleReceiver != null) {
                _collectibleReceiver.AddItem(_selectedCollectible, _selectedCollectible.GetQuantityToAdd());
            }
            BroadcastMessage("SFXBreak");
            GetComponent<SpawnableCrate>().ResetObject();
        }
    }

    private void RandomizeCollectible() {
        int randomIndex = Random.Range(0, _availableCollectibles.Length);
        _selectedCollectible = _availableCollectibles[randomIndex];
    }

    public void DisableCrate() {
        GetComponent<BasicMovement>().enabled = false;
        RandomizeCollectible();
    }

    public void EnableCrate() {
        GetComponent<BasicMovement>().enabled = true;        
    }
}
