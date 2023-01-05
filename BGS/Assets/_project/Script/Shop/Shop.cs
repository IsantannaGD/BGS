using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum OperationType
{
    Buy = 0,
    Sell = 1
}
public class Shop : MonoBehaviour
{
    public Action OnUpdateWallet;
    public Action<string> OnUpdateMessage;
    public Action<Item> OnRemoveItemFromList;

    public float ShopKeeperWallet => shopKeeperWallet;
    public List<Item> ShopItems => _shopItems;


    [SerializeField] private List<Item> _shopItems;

    [SerializeField] private Player _currentCustomer;
    

    [SerializeField] private float shopKeeperWallet = 850f;

    public void Setup(Player p)
    {
        _currentCustomer = p;
    }

    private void UpdateWalletHandler(float value)
    {
        shopKeeperWallet += value;
        OnUpdateWallet?.Invoke();
    }

    public void SellShopItemCallback(Item i)
    {
        if (i is not IPurchasable itemToPurchase)
        {
            return;
        }

        if (!BuyItem(_currentCustomer, i))
        {
            OnUpdateMessage?.Invoke("MoneylessCustomer");
            return;
        }

        float value = i.GetShopValue(OperationType.Buy);
        
        UpdateWalletHandler(value);
        OnUpdateMessage?.Invoke("SuccessPurchase");

        _shopItems.Remove(i);
        OnRemoveItemFromList?.Invoke(i);
    }

    public void BuyCustomerItemCallback(Item i)
    {
        if (i is not ISalable itemToSell)
        {
            OnUpdateMessage?.Invoke("CantSellThis");
            return;
        }

        if (itemToSell.InUse)
        {
            OnUpdateMessage?.Invoke("CantSellEquippedItem");
            return;
        }

        if (!SellItem(_currentCustomer, i))
        {
            OnUpdateMessage?.Invoke("MoneyLessShop");
            return;
        }

        OnUpdateMessage?.Invoke("SuccessSell");

        float value = -i.GetShopValue(OperationType.Sell);

        UpdateWalletHandler(value);
        _shopItems.Add(i);
        OnRemoveItemFromList?.Invoke(i);
    }

    private bool SellItem(Player p, Item i)
    {
        float value = i.GetShopValue(OperationType.Buy);
        if (ShopKeeperWallet < value)
        { return false; }

        p.Inventory.PlayerSellItemHandler(i, value);
        return true;
    }

    private bool BuyItem(Player p, Item i)
    {
        float value = i.GetShopValue(OperationType.Sell);
        if (p.Inventory.Wallet < value)
        { return false; }
        
        p.Inventory.PlayerBuyItemHandler(i, value);
        return true;
    }

    
}
