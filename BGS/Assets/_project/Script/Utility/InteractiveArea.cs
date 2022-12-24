using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class InteractiveArea : MonoBehaviour
{
    public Action<bool, Player> OnTriggerStatus;
    public Action<bool, Player> OnCollisionStatus;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out Player p))
        {
            OnTriggerStatus?.Invoke(true, p);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Player p))
        {
            OnTriggerStatus?.Invoke(false, p);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Player p))
        {
            OnCollisionStatus?.Invoke(true, p);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Player p))
        {
            OnCollisionStatus?.Invoke(false, p);
        }
    }
}
