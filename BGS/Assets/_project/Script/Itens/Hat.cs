using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hat", menuName = "ScriptableObjects/Item/Hat", order = 1)]
public class Hat : Item, ISalable, IPurchasable, IWearable
{
    public readonly ClothType ClothType = ClothType.Hat;

    public void EquipItemHandler(bool isEquipped)
    {
        _isEquipped = isEquipped;
    }
}
