using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemLabel : MonoBehaviour, IPointerDownHandler
{
    public Action<Item> OnSelectItem;

    public Item Item => _currentItem;

    [SerializeField] private Image _bg;
    [SerializeField] private Image _iconImage;
    [SerializeField] private TextMeshProUGUI _itemName;

    [SerializeField] private Item _currentItem;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _highLightedColor;

    public void Setup(Item item)
    {
        _currentItem = item;

        _iconImage.sprite = _currentItem.ItemIcon;
        _itemName.text = _currentItem.Name;

        _bg.color = _defaultColor;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        OnSelectItem?.Invoke(_currentItem);

        _bg.color = _highLightedColor;
    }

    public void SelectItemInListCallback(Item s)
    {
        if (s.Equals(_currentItem))
        {
            _bg.color = _highLightedColor;
            return;
        }

        _bg.color = _defaultColor;
    }
}
