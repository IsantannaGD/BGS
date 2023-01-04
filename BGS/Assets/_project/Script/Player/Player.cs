using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Action OnInteractive;

    public Action<Hat, bool> OnEquipHat;
    public Action<Shirt, bool> OnEquipShirt;
    public Action<Trousers, bool> OnEquipTrousers;

    public InventoryManager Inventory => _inventory;
    public Hat EquippedHat => _equippedHat;
    public Shirt EquippedShirt => _equippedShirt;
    public Trousers EquippedTrousers => _equippedTrousers;

    [SerializeField] private InventoryManager _inventory;

    [SerializeField] private Button _openInventoryDebugger;

    [SerializeField][CanBeNull] private Hat _equippedHat = null;
    [SerializeField][CanBeNull] private Shirt _equippedShirt = null;
    [SerializeField][CanBeNull] private Trousers _equippedTrousers = null;

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
        OnEquipHat += EquipHatHandler;
        OnEquipShirt += EquipShirtHandler;
        OnEquipTrousers += EquipTrousersHandler;

        _openInventoryDebugger.onClick.AddListener(_inventory.OpenInventory);

        _inventory.Setup(this);
    }

    public int CheckEquippedHatID()
    {
        int i = _equippedHat != null ? _equippedHat.ID : -1;

        return i;
    }

    public int CheckEquippedShirtID()
    {
        int i = _equippedShirt != null ? _equippedShirt.ID : -1;

        return i;
    }

    public int CheckEquippedTrousersID()
    {
        int i = _equippedTrousers != null ? _equippedTrousers.ID : -1;

        return i;
    }

    private void EquipHatHandler(Hat h, bool status)
    {
        h.EquipItemHandler(status);
        _inventory.UpdateItemDisplay();

        if (!status)
        {
            _equippedHat = null;
            UpdateEquipSprite(_hat, _defaultHat);
            return;
        }

        if (_equippedHat != null)
        {
            _equippedHat.EquipItemHandler(false);
        }
        
        _equippedHat = h;
        UpdateEquipSprite(_hat, _equippedHat.ItemSprite);
    }

    private void EquipShirtHandler(Shirt s, bool status)
    {

        s.EquipItemHandler(status);
        _inventory.UpdateItemDisplay();

        if (!status)
        {
            _equippedShirt = null;
            UpdateEquipSprite(_shirt, _defaultShirt);
            return;
        }

        if (_equippedShirt != null)
        {
            _equippedShirt.EquipItemHandler(false);
        }

        _equippedShirt = s;
        UpdateEquipSprite(_shirt, _equippedShirt.ItemSprite);
    }

    private void EquipTrousersHandler(Trousers t, bool status)
    {
        t.EquipItemHandler(status);
        _inventory.UpdateItemDisplay();

        if (!status)
        {
            _equippedTrousers = null;
            UpdateEquipSprite(_trousers, _defaultTrousers);
            return;
        }

        if (_equippedTrousers != null)
        {
            _equippedTrousers.EquipItemHandler(false);
        }

        _equippedTrousers = t;
        UpdateEquipSprite(_trousers, _equippedTrousers.ItemSprite);
    }

    private void UpdateEquipSprite(SpriteRenderer i, Sprite newItem)
    {
        i.sprite = newItem;
    }
}
