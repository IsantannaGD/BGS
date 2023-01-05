using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    public Vector2 Velocity;

    [SerializeField] private Rigidbody2D _rigB;
    [SerializeField] private Animator _anim;

    [SerializeField] private float _speed = 4f;
    [SerializeField] private bool _canMove = true;

    private void Start()
    {
        GameController.Instance.OnPlayerInInteraction += CanMoveHandler;
    }

    private void HorizontalMovement()
    {
        _rigB.velocity = new Vector2(Velocity.x * _speed, _rigB.velocity.y);

        SetAnimation();
    }

    private void VerticalMovement()
    {
        _rigB.velocity = new Vector2(_rigB.velocity.x, Velocity.y * _speed);
    }

    private void CanMoveHandler(bool status)
    {
        Velocity = Vector2.zero;
        _rigB.velocity = Velocity;
        _canMove = status;
    }

    private void SetAnimation()
    {
        _anim.SetInteger("HorizontalMovement", (int)Velocity.x);
        if (Velocity.x < 0)
        {
            transform.rotation = new Quaternion(0f, -180f, 0f, 0);
        }
        else
        {
            transform.rotation = new Quaternion(0f, 0f, 0f, 0);
        }
    }

    private void FixedUpdate()
    {
        if (_canMove)
        {
            HorizontalMovement();
            VerticalMovement();
        }
    }
}
