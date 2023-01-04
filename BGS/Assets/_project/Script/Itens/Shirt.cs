using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shirt", menuName = "ScriptableObjects/Item/Shirt", order = 1)]
public class Shirt : Item, ISalable, IPurchasable, IWearable
{
    public readonly ClothType ClothType = ClothType.Shirt;

    private void OnDisable()
    {
        _isEquipped = false;
    }

    public void EquipItemHandler(bool isEquipped)
    {
        _isEquipped = isEquipped;
    }
}
