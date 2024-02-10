using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammunition : MonoBehaviour
{
    [SerializeField] private int _ammoCount = 10;
    [SerializeField] private int _maxAmmo = 10;
    private int _rechargeCount = 5;

    public int GetAmmoCount() {
        return _ammoCount;
    }

    public void SpendAmmo() {
        _ammoCount -= 1;
    }

    public void RechargeAmmo(int quantityToAdd) {
        _rechargeCount = quantityToAdd;
        if (_ammoCount + _rechargeCount < _maxAmmo){
            _ammoCount += _rechargeCount;
        }
        else {
            _ammoCount = _maxAmmo;
        }
    }

}
