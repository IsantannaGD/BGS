using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Trousers", menuName = "ScriptableObjects/Item/Trousers", order = 1)]
public class Trousers : Item, ISalable, IPurchasable, IWearable
{
    public ClothType ClothType => _clothType;
    public bool InUse => _isEquipped;

    private readonly ClothType _clothType = ClothType.Trousers;

    private void OnDisable()
    {
        _isEquipped = false;
    }
    public void EquipItemHandler(bool isEquipped)
    {
        _isEquipped = isEquipped;
    }
}
