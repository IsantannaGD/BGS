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
    public PlayerPhysics PlayerPhysics => _playerPhysics;

    [SerializeField] private Inventory _inventory;
    [SerializeField] private PlayerPhysics _playerPhysics;

    [SerializeField] private SpriteRenderer _hat;
    [SerializeField] private SpriteRenderer _shirt;
    [SerializeField] private SpriteRenderer _trousers;

    [SerializeField] private Sprite _defaultHat;
    [SerializeField] private Sprite _defaultShirt;
    [SerializeField] private Sprite _defaultTrousers;

    private bool _waitTimeActive;
    private readonly float _waitTime = 0.8f;

    public void OpenInventory()
    {
        if (_waitTimeActive)
        {
            return;
        }

        OnInventoryOpen?.Invoke();
        _waitTimeActive = true;
        StartCoroutine(WaitTimeRelease());
    }
    private void Start()
    {
        Initializations();
    }

    private void Initializations()
    {
        _inventory.UpdatePlayerOutfit += UpdateEquipSprite;
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

    private IEnumerator WaitTimeRelease()
    {
        yield return new WaitForSeconds(_waitTime);

        _waitTimeActive = false;
    }
}
