using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Action OnInteractive;

    public float Wallet => _wallet;
    public List<Item> Inventory => _inventory;

    [SerializeField] private List<Item> _inventory;
    [SerializeField] private float _wallet;

    public void PlayerBuyItemHandler(IPurchasable item, float value)
    {
        UseMoneyInWalletHandler(value);
        _inventory.Add(item as Item);
    }

    private void UseMoneyInWalletHandler(float value)
    {
        if (value > _wallet)
        { throw new ArgumentException(); }

        _wallet -= value;
    }
}
