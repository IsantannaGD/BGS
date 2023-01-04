using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : ItemListBuilder
{
    public float Wallet => _wallet;
    public List<Item> InventoryList => _inventoryList;

    [SerializeField] private Player _inventoryOwner;
    [SerializeField] private List<Item> _inventoryList;
    [SerializeField] private GameObject _equippedIndication;
    [SerializeField] private float _wallet;

    private bool _isOpen = false;

    public void Setup(Player p)
    {
        _inventoryOwner = p;
        UpdateWalletDisplay(_wallet);
    }
    public void PlayerBuyItemHandler(IPurchasable item, float value)
    {
        UseMoneyInWalletHandler(value);
        _inventoryList.Add(item as Item);
    }

    public void PlayerSellItemHandler(ISalable item, float value)
    {
        _wallet += value;
        _inventoryList.Remove(item as Item);
    }

    public void UpdateItemDisplay()
    {
        ShowSelectedItemHandler();
    }

    public void OpenInventory()
    {
        _isOpen = !_isOpen;

        if (_isOpen)
        {
            ClearList();
            CreateList(_inventoryList);
        }

        PanelAnim(_isOpen);
    }

    protected override void SelectItemHandler(Item i)
    {
        OnSelectItemInList?.Invoke(i);
        currentItem = i;
        currentValue = currentItem.GetShopValue(OperationType.Sell);
        ShowSelectedItemHandler();
    }

    protected override void InteractiveButtonHandler()
    {
        switch (currentItem.ItemType)
        {
            case ItemType.Consumable:
                //TODO: Not Implemented in this version;
                break;
            case ItemType.Weapon:
                //TODO: Not Implemented in this version;
                break;
            case ItemType.Clothe:
                IWearable wearable = currentItem as IWearable;
                CheckClothType(wearable);
                break;
        }
    }

    protected override void ShowSelectedItemHandler()
    {
        base.ShowSelectedItemHandler();

        if (currentItem.EquippedChecker())
        {
            _equippedIndication.SetActive(true);
            interactionButton.GetComponentInChildren<TextMeshProUGUI>().text = "UnEquip";
            return;
        }

        _equippedIndication.SetActive(false);
        interactionButton.GetComponentInChildren<TextMeshProUGUI>().text = "Equip";
    }

    private void UseMoneyInWalletHandler(float value)
    {
        if (value > _wallet)
        { throw new ArgumentException(); }

        _wallet -= value;
    }

    private void CheckClothType(IWearable iW)
    {
        Hat h = iW as Hat;

        if (h != null)
        {
            if (iW.WearItem(_inventoryOwner, ClothType.Hat, currentItem))
            {
                ShowSelectedItemHandler();
            }
            return;
        }

        Shirt s = iW as Shirt;

        if (s != null)
        {
            if (iW.WearItem(_inventoryOwner, ClothType.Shirt, currentItem))
            {
                ShowSelectedItemHandler();
            }

            return;
        }

        Trousers t = iW as Trousers;

        if (t != null)
        {
            if (iW.WearItem(_inventoryOwner, ClothType.Trousers, currentItem))
            {
                ShowSelectedItemHandler();
            }
        }
    }
}
