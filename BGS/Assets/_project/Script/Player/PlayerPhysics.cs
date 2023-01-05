using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    public Vector2 Velocity;

    [SerializeField] private CharacterController _charControl;

    [SerializeField] private float _speed;

    private void HorizontalMovement()
    {
        // _charControl.
        // _charControl.velocity = new Vector2(Velocity.x * _speed, _charControl.velocity.y);
    }
}
