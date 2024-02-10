using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private int playerCoins = 0;

    public int GetCoinQuantity() {
        return playerCoins;
    }

    public void AddCoins(int quantityToAdd) {
        playerCoins += quantityToAdd;
        Debug.Log(playerCoins);
    }
}
