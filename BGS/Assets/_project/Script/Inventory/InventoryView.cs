using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryView : ItemListBuilder
{
    [SerializeField] private Player _inventoryOwner;
    [SerializeField] private GameObject _equippedIndication;

    private bool _isOpen = false;

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
            case ItemType.Furniture:
                //TODO: Not Implemented in this version;
                break;
            case ItemType.Clothe:
                _inventoryOwner.Inventory.TryEquipCloth(currentItem);
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

    protected override void Subscriptions()
    {
        base.Subscriptions();
        _inventoryOwner.OnInventoryOpen += OpenInventory;
        _inventoryOwner.Inventory.OnUpdateItem += UpdateItemDisplay;
    }

    protected override void UnSubscriptions()
    {
        base.UnSubscriptions();
        _inventoryOwner.OnInventoryOpen -= OpenInventory;
        _inventoryOwner.Inventory.OnUpdateItem -= UpdateItemDisplay;
    }

    private void UpdateItemDisplay()
    {
        ShowSelectedItemHandler();
    }

    private void OpenInventory()
    {
        _isOpen = !_isOpen;

        if (_isOpen)
        {
            ClearList();
            CreateList(_inventoryOwner.Inventory.InventoryList);
            UpdateWalletDisplay(_inventoryOwner.Inventory.Wallet);
        }

        PanelAnim(_isOpen);
    }
}
