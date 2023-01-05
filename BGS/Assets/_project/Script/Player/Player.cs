using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Action OnInteractive;
    public Action OnInventoryOpen;
    
    public Inventory Inventory => _inventory;

    [SerializeField] private Inventory _inventory;

    [SerializeField] private Button _openInventoryDebugger;

    [SerializeField] private SpriteRenderer _hat;
    [SerializeField] private SpriteRenderer _shirt;
    [SerializeField] private SpriteRenderer _trousers;

    [SerializeField] private Sprite _defaultHat;
    [SerializeField] private Sprite _defaultShirt;
    [SerializeField] private Sprite _defaultTrousers;

    private void Start()
    {
        Initializations();
    }

    private void Initializations()
    {
        _inventory.UpdatePlayerOutfit += UpdateEquipSprite;

        _openInventoryDebugger.onClick.AddListener(() => OnInventoryOpen?.Invoke());
    }


    private void UpdateEquipSprite(ClothType c, Item newItem)
    {
        switch (c)
        {
            case ClothType.Hat:
                if (newItem == null)
                {
                    _hat.sprite = _defaultHat;
                    return;
                }

                _hat.sprite = newItem.ItemSprite;
                break;

            case ClothType.Shirt:
                if (newItem == null)
                {
                    _shirt.sprite = _defaultShirt;
                    return;
                }

                _shirt.sprite = newItem.ItemSprite;
                break;

            case ClothType.Trousers:
                if (newItem == null)
                {
                    _trousers.sprite = _defaultTrousers;
                    return;
                }

                _trousers.sprite = newItem.ItemSprite;
                break;
        }
    }
}
