using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleReceiver : MonoBehaviour
{
    [SerializeField] private Ammunition ammunition;
    [SerializeField] private TextScore textScore;
    [SerializeField] private CoinManager coinManager;
    [SerializeField] private int scoreForShuriken = 50;
    [SerializeField] private int scoreForCoin = 100;

    public void AddItem(ColScore collectible, int quantityToAdd) {
        textScore.AddScore(quantityToAdd);
    }

    public void AddItem(ColShuriken collectible, int quantityToAdd) {
        ammunition.RechargeAmmo(quantityToAdd);
        textScore.AddScore(scoreForShuriken);
    }

    public void AddItem(ColCoins collectible, int quantityToAdd) {
        coinManager.AddCoins(quantityToAdd);
        textScore.AddScore(scoreForCoin);
    }

    public void AddItem(Collectible collectible, int quantityToAdd) {
        if (collectible.GetType() == typeof(ColScore)) {
            AddItem((ColScore)collectible, quantityToAdd);
        }

        if (collectible.GetType() == typeof(ColShuriken)) {
            AddItem((ColShuriken)collectible, quantityToAdd);           
        }

        if (collectible.GetType() == typeof(ColCoins)) {
            AddItem((ColCoins)collectible, quantityToAdd);           
        }
    }
}
