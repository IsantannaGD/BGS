using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Player _player;

    private InputBinder _inputBinder;

    private void Awake()
    {
        Initializations();
        Subscriptions();
    }

    private void OnDestroy()
    {
        UnSubscriptions();
    }

    private void Initializations()
    {
        _inputBinder = new InputBinder();
        _inputBinder.Enable();
    }

    private void Subscriptions()
    {
        _inputBinder.Keyboard.UpMove.performed += (ctx) => _player.PlayerPhysics.Velocity.y += 1;
        _inputBinder.Keyboard.UpMove.canceled += (ctx) => _player.PlayerPhysics.Velocity.y -= 1;

        _inputBinder.Keyboard.DownMove.performed += (ctx) => _player.PlayerPhysics.Velocity.y -= 1;
        _inputBinder.Keyboard.DownMove.canceled += (ctx) => _player.PlayerPhysics.Velocity.y += 1;

        _inputBinder.Keyboard.RightMove.performed += (ctx) => _player.PlayerPhysics.Velocity.x += 1;
        _inputBinder.Keyboard.RightMove.canceled += (ctx) => _player.PlayerPhysics.Velocity.x -= 1;

        _inputBinder.Keyboard.LeftMove.performed += (ctx) => _player.PlayerPhysics.Velocity.x -= 1;
        _inputBinder.Keyboard.LeftMove.canceled += (ctx) => _player.PlayerPhysics.Velocity.x += 1;

        _inputBinder.Keyboard.Interactive.performed += (ctx) => _player.OnInteractive?.Invoke();
        _inputBinder.Keyboard.Inventory.performed += (ctx) => _player.OpenInventory();
    }

    private void UnSubscriptions()
    {
        _inputBinder.Disable();
    }
}
