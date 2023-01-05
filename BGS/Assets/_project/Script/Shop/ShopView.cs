using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShopView : ItemListBuilder
{
    [SerializeField] private OperationType _operationType;

    [SerializeField] private List<FeedbackMessage> _messageList;

    [SerializeField] private Shopkeeper _shopOwner;
    [SerializeField] private Player _currentCustomer;

    [SerializeField] private TextMeshProUGUI _customerWallet;

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
                _shopOwner.Shop.SellShopItemCallback(currentItem);
                break;
            case OperationType.Sell:
                _shopOwner.Shop.BuyCustomerItemCallback(currentItem);
                break;
        }
    }

    protected override void Subscriptions()
    {
        base.Subscriptions();
        _shopOwner.OnSetupShopView += Setup;
        _shopOwner.Shop.OnUpdateWallet += UpdateWalletDisplay;
        _shopOwner.Shop.OnUpdateMessage += UpdateMessageHandler;
        _shopOwner.Shop.OnRemoveItemFromList += RemoveItemFromList;
    }

    protected override void UnSubscriptions()
    {
        base.UnSubscriptions();
        _shopOwner.OnSetupShopView -= Setup;
        _shopOwner.Shop.OnUpdateWallet -= UpdateWalletDisplay;
        _shopOwner.Shop.OnUpdateMessage -= UpdateMessageHandler;
        _shopOwner.Shop.OnRemoveItemFromList -= RemoveItemFromList;
    }

    protected override void CancelHandler()
    {
        PanelAnim(false);
        _shopOwner.InitialDialogueCallback();
    }

    private void Setup(OperationType o, Player c, TextController t)
    {
        _currentCustomer = c;
        _operationType = o;
        textController = t;

        ClearList();

        switch (_operationType)
        {
            case OperationType.Buy:
                CreateList(_shopOwner.Shop.ShopItems);
                UpdateMessageHandler("BuyMessage");
                interactionButton.GetComponentInChildren<TextMeshProUGUI>().text = "Purchase";
                break;
            case OperationType.Sell:
                CreateList(_currentCustomer.Inventory.InventoryList);
                UpdateMessageHandler("SellMessage");
                interactionButton.GetComponentInChildren<TextMeshProUGUI>().text = "Sell";
                break;
        }

        UpdateWalletDisplay(_shopOwner.Shop.ShopKeeperWallet);
        UpdateCustomerWalletDisplay(_currentCustomer.Inventory.Wallet);
        PanelAnim(true);
    }

    private void UpdateWalletDisplay()
    {
        UpdateWalletDisplay(_shopOwner.Shop.ShopKeeperWallet);
        UpdateCustomerWalletDisplay(_currentCustomer.Inventory.Wallet);
    }

    private void UpdateCustomerWalletDisplay(float value)
    {
        _customerWallet.text = value.ToString("000");
    }

    private void UpdateMessageHandler(string name)
    {
        string m = " ";

        foreach (FeedbackMessage feedbackMessage in _messageList)
        {
            if (feedbackMessage.Name == name)
            {
                m = feedbackMessage.Message;
            }
        }

        textController.SetContextText(m);
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
