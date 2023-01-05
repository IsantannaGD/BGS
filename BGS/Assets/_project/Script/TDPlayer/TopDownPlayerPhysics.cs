using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerPhysics : MonoBehaviour
{
    public Vector2 Velocity;

    [SerializeField] private Rigidbody2D _rigB;
    [SerializeField] private Animator _anim;

    [SerializeField] private float _speed = 4f;

    private void HorizontalMovement()
    {
        _rigB.velocity = new Vector2(Velocity.x * _speed, _rigB.velocity.y);

        SetAnimation();
    }

    private void VerticalMovement()
    {
        _rigB.velocity = new Vector2(_rigB.velocity.x, Velocity.y * _speed);
    }

    private void SetAnimation()
    {
        _anim.SetFloat("Horizontal", Velocity.x);
        _anim.SetFloat("Vertical", Velocity.y);
        _anim.SetFloat("Speed", Velocity.sqrMagnitude);
    }

    private void FixedUpdate()
    {
            HorizontalMovement();
            VerticalMovement();
            SetAnimation();
    }
}
