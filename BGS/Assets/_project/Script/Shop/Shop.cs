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
    private const string BuyMessage = "What do you want purchase, today?";
    private const string SellMessage = "Well, show me what do you have...";

    private const string MoneylessCustomer = "You don't have money to this...";
    private const string SuccessPurchase = "Great, thank you for your preference!";

    private const string MoneyLessShop = "The ShopKeeper don't have money to buy your item...";
    private const string CantSellThis = "It's not a salable Item!";
    private const string SuccessSell = "Wonderful, bring other items in future!";

    public Action<Item> OnSelectItemInList;
    public Action OnReturn;

    public float ShopKeeperWallet => _shopKeeperWallet;

    [SerializeField] private OperationType _operationType;
    [SerializeField] private List<Item> _shopItens;
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private ItemShopLabel _labelPrefab;

    [SerializeField] private TextController _textController;
    [SerializeField] private TextMeshProUGUI _selectedItemName;
    [SerializeField] private TextMeshProUGUI _selectedItemDescription;
    [SerializeField] private TextMeshProUGUI _selectedItemType;
    [SerializeField] private TextMeshProUGUI _selectedItemValue;
    [SerializeField] private Image _selectedItemImage;
    [SerializeField] private Button _interactionButton;
    [SerializeField] private Button _cancelInteractionButton;

    [SerializeField] private Item _currentItem;
    [SerializeField] private float _currentValue;
    [SerializeField] private float _animTime = 0.5f;
    [SerializeField] private float _shopKeeperWallet = 850f;
    [SerializeField] private List<ItemShopLabel> _createdItems;

    [SerializeField] private Player _currentCustomer;

    private void Start()
    {
        Initializations();
    }

    private void Initializations()
    {
        _interactionButton.onClick.AddListener(InteractiveButtonHandler);
        _cancelInteractionButton.onClick.AddListener(CancelPurchaseItemHandler);

        gameObject.SetActive(false);
    }

    public void Setup(OperationType o, Player c)
    {
        _currentCustomer = c;
        _operationType = o;

        ClearList();

        switch (_operationType)
        {
            case OperationType.Buy:
                CreateList(_shopItens);
                _textController.SetContextText(BuyMessage);
                _interactionButton.GetComponentInChildren<TextMeshProUGUI>().text = "Purchase";
                break;
            case OperationType.Sell:
                CreateList(_currentCustomer.Inventory);
                _textController.SetContextText(SellMessage);
                _interactionButton.GetComponentInChildren<TextMeshProUGUI>().text = "Sell";
                break;
        }

        PanelAnim(true);
    }

    public void UpdateWalletHandler(float value)
    {
        _shopKeeperWallet += value;
    }

    private void CreateList(List<Item> items)
    {
        foreach (Item item in items)
        {
            ItemShopLabel n = Instantiate(_labelPrefab, _spawnPoint.transform);
            n.Setup(item);

            OnSelectItemInList += n.SelectItemInListCallback;
            n.OnSelectItem += SelectItemHandler;

            _createdItems.Add(n);
        }
    }

    private void SelectItemHandler(Item i)
    {
        OnSelectItemInList?.Invoke(i);
        _currentItem = i;
        _currentValue = _currentItem.GetShopValue(_operationType);
        ShowSelectedItemHandler();
    }

    private void InteractiveButtonHandler()
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

    private void SellShopItemCallback()
    {
        IPurchasable itemToPurchase = _currentItem as IPurchasable;

        if (itemToPurchase == null)
        {return; }

        if (!itemToPurchase.BuyItem(_currentCustomer, _currentValue))
        {
            _textController.SetContextText(MoneylessCustomer);
            return;
        }
        
        UpdateWalletHandler(_currentValue);
        _textController.SetContextText(SuccessPurchase);

        _shopItens.Remove(_currentItem);
        RemoveItemFromList(_currentItem);
    }

    private void BuyCustomerItemCallback()
    {
        ISalable itemToSell = _currentItem as ISalable;

        if (itemToSell == null)
        {
            _interactionButton.interactable = false;
            _textController.SetContextText(CantSellThis);
            return;
        }

        if (!itemToSell.SellItem(_currentCustomer, _currentItem.GetShopValue(_operationType), this))
        {
            _textController.SetContextText(MoneyLessShop);
            return;
        }


        _textController.SetContextText(SuccessSell);

        UpdateWalletHandler(-_currentValue);
        _shopItens.Add(_currentItem);
        RemoveItemFromList(_currentItem);
    }

    private void CancelPurchaseItemHandler()
    {
        PanelAnim(false);
        OnReturn?.Invoke();
    }

    private void RemoveItemFromList(Item i)
    {
        foreach (ItemShopLabel label in _createdItems)
        {
            if (label.Item.Equals(i))
            {
                _createdItems.Remove(label);
                OnSelectItemInList -= label.SelectItemInListCallback;
                label.OnSelectItem -= SelectItemHandler;

                _currentItem = null;
                Destroy(label.gameObject);

                ClearSelection();
                return;
            }
        }
    }

    private void ShowSelectedItemHandler()
    {
        _selectedItemName.text = _currentItem.Name;
        _selectedItemDescription.text = _currentItem.Description;
        _selectedItemImage.gameObject.SetActive(true);
        _selectedItemImage.sprite = _currentItem.ItemSprite;
        _selectedItemImage.DOFade(1f, 0.5f);
        _selectedItemType.text = _currentItem.ItemType.ToString();
        _selectedItemValue.text = $"{_currentValue}";
        _interactionButton.interactable = true;
    }

    private void ClearSelection()
    {
        _selectedItemName.text = " ";
        _selectedItemDescription.text = " ";
        _selectedItemImage.DOFade(0f, 0.5f).OnComplete(() => {_selectedItemImage.gameObject.SetActive(false);});
        _selectedItemType.text = " ";
        _selectedItemValue.text = " ";
        _currentValue = 0f;
        _currentItem = null;
        _interactionButton.interactable = false;

    }

    private void ClearList()
    {
        foreach (ItemShopLabel label in _createdItems)
        {
            OnSelectItemInList -= label.SelectItemInListCallback;
            label.OnSelectItem -= SelectItemHandler;
            Destroy(label.gameObject);
        }

        _createdItems.Clear();
        ClearSelection();
    }
    private void PanelAnim(bool status)
    {
        if (status)
        {
            gameObject.SetActive(true);
            gameObject.transform.DOScale(1f, _animTime);
            return;
        }

        gameObject.transform.DOScale(0f, _animTime).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
