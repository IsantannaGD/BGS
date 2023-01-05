using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shirt", menuName = "ScriptableObjects/Item/Shirt", order = 1)]
public class Shirt : Item, ISalable, IPurchasable, IWearable
{
    public ClothType ClothType => _clothType;
    public bool InUse => _isEquipped;

    private readonly ClothType _clothType = ClothType.Shirt;

    private void OnDisable()
    {
        _isEquipped = false;
    }

    public void EquipItemHandler(bool isEquipped)
    {
        _isEquipped = isEquipped;
    }
}
