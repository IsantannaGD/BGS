using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hat", menuName = "ScriptableObjects/Item/Hat", order = 1)]
public class Hat : Item, ISalable, IPurchasable, IWearable
{
    public ClothType ClothType => _clothType;
    public bool InUse => _isEquipped;

    private readonly ClothType _clothType = ClothType.Hat;
    private float h;

    private void OnDisable()
    {
        _isEquipped = false;
    }

    public void EquipItemHandler(bool isEquipped)
    {
        _isEquipped = isEquipped;
    }

    
    
}
