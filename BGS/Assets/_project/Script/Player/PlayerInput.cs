using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerPhysics _physics;

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

    }

    private void UnSubscriptions()
    {
        _inputBinder.Disable();
    }
}
