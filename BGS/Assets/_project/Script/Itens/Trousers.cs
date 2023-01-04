using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Trousers", menuName = "ScriptableObjects/Item/Trousers", order = 1)]
public class Trousers : Item, ISalable, IPurchasable, IWearable
{
    public readonly ClothType ClothType = ClothType.Trousers;

    public void EquipItemHandler(bool isEquipped)
    {
        _isEquipped = isEquipped;
    }
}
