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
    public Action<Item> OnSelectItemInList;

    [SerializeField] private OperationType _operationType;
    [SerializeField] private Item[] _shopItens;
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private ItemShopLabel _labelPrefab;

    [SerializeField] private TextMeshProUGUI _selectedItemName;
    [SerializeField] private TextMeshProUGUI _selectedItemDescription;
    [SerializeField] private TextMeshProUGUI _selectedItemType;
    [SerializeField] private TextMeshProUGUI _selectedItemValue;
    [SerializeField] private Image _selectedItemImage;
    [SerializeField] private Button _purchaseButton;
    [SerializeField] private Button _cancelPurchaseButton;

    [SerializeField] private Item _currentItem;
    [SerializeField] private float _currentValue;
    [SerializeField] private List<ItemShopLabel> _createdItems;

    [SerializeField] private Player _currentCustomer;

    private void Start()
    {
        Initializations();
    }

    private void Initializations()
    {
        _purchaseButton.onClick.AddListener(BuyItemHandler);
        _cancelPurchaseButton.onClick.AddListener(CancelPurchaseItemHandler);

    }

    private void Setup(OperationType o, Player c)
    {
        _currentCustomer = c;

        switch (o)
        {
            case OperationType.Buy:
                CreateList(_shopItens);
                break;
            case OperationType.Sell:
                break;
        }
    }

    private void CreateList(Item[] items)
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
        _currentItem = i;
        _currentValue = _currentItem.GetShopValue(_operationType);
        OnSelectItemInList?.Invoke(i);
        ShowSelectedItemHandler();
    }

    private void BuyItemHandler()
    {

    }

    private void CancelPurchaseItemHandler()
    {

    }

    private void ShowSelectedItemHandler()
    {
        _selectedItemName.text = _currentItem.Name;
        _selectedItemDescription.text = _currentItem.Description;
        _selectedItemImage.sprite = _currentItem.ItemSprite;
        _selectedItemImage.DOFade(1f, 05f);
        _selectedItemType.text = _currentItem.ItemType.ToString();
        _selectedItemValue.text = $"{_currentValue}";
    }

    private void ClearSelection()
    {
        _selectedItemName.text = " ";
        _selectedItemDescription.text = " ";
        _selectedItemImage.DOFade(0f, 05f);
        _selectedItemType.text = " ";
        _selectedItemValue.text = " ";

    }
}
