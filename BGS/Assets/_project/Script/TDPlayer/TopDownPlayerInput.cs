using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopDownPlayerInput : MonoBehaviour
{
    [SerializeField] private TopDownPlayerPhysics _player;

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
        _inputBinder.Keyboard.UpMove.performed += (ctx) => _player.Velocity.y += 1;
        _inputBinder.Keyboard.UpMove.canceled += (ctx) => _player.Velocity.y -= 1;

        _inputBinder.Keyboard.DownMove.performed += (ctx) => _player.Velocity.y -= 1;
        _inputBinder.Keyboard.DownMove.canceled += (ctx) => _player.Velocity.y += 1;

        _inputBinder.Keyboard.RightMove.performed += (ctx) => _player.Velocity.x += 1;
        _inputBinder.Keyboard.RightMove.canceled += (ctx) => _player.Velocity.x -= 1;

        _inputBinder.Keyboard.LeftMove.performed += (ctx) => _player.Velocity.x -= 1;
        _inputBinder.Keyboard.LeftMove.canceled += (ctx) => _player.Velocity.x += 1;

        _inputBinder.Keyboard.ChangeScene.performed += (ctx) => ChangeScene();
    }
    private void UnSubscriptions()
    {
        _inputBinder.Disable();
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("StoreScene");
    }
}
