using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Consumable = 0,
    Furniture = 1,
    Clothe = 2
}
public abstract class Item : ScriptableObject, IComparable, IEquatable<Item>
{
    public int ID => _id;
    public string Name => _name;
    public string Description => _description;
    public ItemType ItemType => _itemType;
    public Sprite ItemSprite => _sprite;
    public Sprite ItemIcon => _icon;
    
    [SerializeField] protected bool _isEquipped;

    [SerializeField] private int _id;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private float _defaultValue;
    [SerializeField] private ItemType _itemType;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Sprite _icon;
    public int CompareTo(object obj)
    {
        Item a = obj as Item;

        if (a == null || a._id < _id)
        {
            return -1;
        }

        if (a._id == _id)
        {
            return 0;
        }

        return 1;
    }

    public float GetShopValue(OperationType o)
    {
        switch (o)
        {
            case OperationType.Buy:

                return _defaultValue;
                break;
            case OperationType.Sell:
                return _defaultValue * 0.7f;
                break;
        }

        return -1;
    }

    public bool EquippedChecker()
    {
        return _isEquipped;
    }

    public bool Equals(Item other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return base.Equals(other) && _id == other._id && _name == other._name && _description == other._description && _defaultValue.Equals(other._defaultValue) && Equals(_sprite, other._sprite) && Equals(_icon, other._icon);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Item)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), _id, _name, _description, _defaultValue, _sprite, _icon);
    }
}
