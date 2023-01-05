using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Action OnUpdateItem;

    public Action<ClothType, Item> UpdatePlayerOutfit;

    public float Wallet => _wallet;
    public List<Item> InventoryList => _inventoryList;
    public Hat EquippedHat => _equippedHat;
    public Shirt EquippedShirt => _equippedShirt;
    public Trousers EquippedTrousers => _equippedTrousers;

    [SerializeField]private List<Item> _inventoryList;

    [SerializeField][CanBeNull] private Hat _equippedHat = null;
    [SerializeField][CanBeNull] private Shirt _equippedShirt = null;
    [SerializeField][CanBeNull] private Trousers _equippedTrousers = null;
    
    [SerializeField]private float _wallet;

    public void PlayerBuyItemHandler(Item item, float value)
    {
        UseMoneyInWalletHandler(value);
        _inventoryList.Add(item);
    }

    public void PlayerSellItemHandler(Item item, float value)
    {
        _wallet += value;
        _inventoryList.Remove(item);
    }

    private void UseMoneyInWalletHandler(float value)
    {
        if (value > _wallet)
        { throw new ArgumentException(); }

        _wallet -= value;
    }

    public void TryEquipCloth(Item i)
    {
        if (i is not IWearable cloth)
        {
            return;
        }

        bool status = true;

        switch (cloth.ClothType)
        {
            case ClothType.Hat:

                int hID = _equippedHat != null ? _equippedHat.ID : -1;

                if (hID == i.ID)
                {
                    status = false;
                }
                
                EquipHatHandler(cloth as Hat, status);

                break;
            case ClothType.Shirt:

                int sID = _equippedShirt != null ? _equippedShirt.ID : -1;

                if (sID == i.ID)
                {
                    status = false;
                }
                
                EquipShirtHandler(cloth as Shirt, status);

                break;
            case ClothType.Trousers:

                int tID = _equippedTrousers != null ? _equippedTrousers.ID : -1;

                if (tID == i.ID)
                {
                    status = false;
                }

                EquipTrousersHandler(cloth as Trousers, status);

                break;
        }
    }

    private void EquipHatHandler(Hat h, bool status)
    {
        h.EquipItemHandler(status);
        OnUpdateItem?.Invoke();

        if (!status)
        {
            _equippedHat = null;
            UpdatePlayerOutfit?.Invoke(ClothType.Hat, null);
            return;
        }

        if (_equippedHat != null)
        {
            _equippedHat.EquipItemHandler(false);
        }
        
        _equippedHat = h;
        UpdatePlayerOutfit?.Invoke(ClothType.Hat, _equippedHat);
    }

    private void EquipShirtHandler(Shirt s, bool status)
    {

        s.EquipItemHandler(status);
        OnUpdateItem?.Invoke();

        if (!status)
        {
            _equippedShirt = null;
            UpdatePlayerOutfit?.Invoke(ClothType.Shirt, null);
            return;
        }

        if (_equippedShirt != null)
        {
            _equippedShirt.EquipItemHandler(false);
        }

        _equippedShirt = s;
        UpdatePlayerOutfit?.Invoke(ClothType.Shirt, _equippedShirt);
    }

    private void EquipTrousersHandler(Trousers t, bool status)
    {
        t.EquipItemHandler(status);
        OnUpdateItem?.Invoke();

        if (!status)
        {
            _equippedTrousers = null;
            UpdatePlayerOutfit?.Invoke(ClothType.Trousers, null);
            return;
        }

        if (_equippedTrousers != null)
        {
            _equippedTrousers.EquipItemHandler(false);
        }

        _equippedTrousers = t;
        UpdatePlayerOutfit?.Invoke(ClothType.Trousers, _equippedTrousers);
    }
}
