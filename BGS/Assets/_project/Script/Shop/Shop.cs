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
public class Shop : ItemListBuilder
{
    private const string BuyMessage = "What do you want purchase, today?";
    private const string SellMessage = "Well, show me what do you have...";

    private const string MoneylessCustomer = "You don't have money to this...";
    private const string SuccessPurchase = "Great, thank you for your preference!";

    private const string MoneyLessShop = "The ShopKeeper don't have money to buy your item...";
    private const string CantSellThis = "It's not a salable Item!";
    private const string CantSellEquippedItem = "You can't sell equipped items!, unequip him to sell.";
    private const string SuccessSell = "Wonderful, bring other items in future!";

    public float ShopKeeperWallet => shopKeeperWallet;

    [SerializeField] private OperationType _operationType;
    [SerializeField] private List<Item> _shopItens;

    [SerializeField] private Player _currentCustomer;
    [SerializeField] private TextMeshProUGUI _customerWallet;

    [SerializeField] private float shopKeeperWallet = 850f;
    
    public void Setup(OperationType o, Player c, TextController t)
    {
        _currentCustomer = c;
        _operationType = o;
        textController = t;

        ClearList();

        switch (_operationType)
        {
            case OperationType.Buy:
                CreateList(_shopItens);
                textController.SetContextText(BuyMessage);
                interactionButton.GetComponentInChildren<TextMeshProUGUI>().text = "Purchase";
                break;
            case OperationType.Sell:
                CreateList(_currentCustomer.Inventory.InventoryList);
                textController.SetContextText(SellMessage);
                interactionButton.GetComponentInChildren<TextMeshProUGUI>().text = "Sell";
                break;
        }

        UpdateWalletDisplay(shopKeeperWallet);
        UpdateCustomerWalletDisplay(_currentCustomer.Inventory.Wallet);
        PanelAnim(true);
    }

    public void UpdateWalletHandler(float value)
    {
        shopKeeperWallet += value;
        UpdateWalletDisplay(shopKeeperWallet);
        UpdateCustomerWalletDisplay(_currentCustomer.Inventory.Wallet);
    }

    protected override void SelectItemHandler(Item i)
    {
        OnSelectItemInList?.Invoke(i);
        currentItem = i;
        currentValue = currentItem.GetShopValue(_operationType);
        ShowSelectedItemHandler();
    }

    protected override void InteractiveButtonHandler()
    {
        switch (_operationType)
        {
            case OperationType.Buy:
                SellShopItemCallback();
                break;
            case OperationType.Sell:
                BuyCustomerItemCallback();
                break;
        }
    }

    private void UpdateCustomerWalletDisplay(float value)
    {
        _customerWallet.text = value.ToString("000");
    }

    private void SellShopItemCallback()
    {
        IPurchasable itemToPurchase = currentItem as IPurchasable;

        if (itemToPurchase == null)
        {return; }

        if (!itemToPurchase.BuyItem(_currentCustomer, currentValue))
        {
            textController.SetContextText(MoneylessCustomer);
            return;
        }
        
        UpdateWalletHandler(currentValue);
        textController.SetContextText(SuccessPurchase);

        _shopItens.Remove(currentItem);
        RemoveItemFromList(currentItem);
    }

    private void BuyCustomerItemCallback()
    {
        if (currentItem.EquippedChecker())
        {
          textController.SetContextText(CantSellEquippedItem);
          return;
        }

        ISalable itemToSell = currentItem as ISalable;

        if (itemToSell == null)
        {
            interactionButton.interactable = false;
            textController.SetContextText(CantSellThis);
            return;
        }

        if (!itemToSell.SellItem(_currentCustomer, currentItem.GetShopValue(_operationType), this))
        {
            textController.SetContextText(MoneyLessShop);
            return;
        }


        textController.SetContextText(SuccessSell);

        UpdateWalletHandler(-currentValue);
        _shopItens.Add(currentItem);
        RemoveItemFromList(currentItem);
    }

    private void RemoveItemFromList(Item i)
    {
        foreach (ItemLabel label in createdItems)
        {
            if (label.Item.Equals(i))
            {
                createdItems.Remove(label);
                OnSelectItemInList -= label.SelectItemInListCallback;
                label.OnSelectItem -= SelectItemHandler;

                currentItem = null;
                Destroy(label.gameObject);

                ClearSelection();
                return;
            }
        }
    }
}
