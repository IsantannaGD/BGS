using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Message", menuName = "ScriptableObjects/Text/FeedbackMessage", order = 1)]
public class FeedbackMessage : ScriptableObject, IEquatable<FeedbackMessage>
{
    public int ID => _id;
    public string Name => _name;
    public string Message => _message;

    [SerializeField] private int _id;
    [SerializeField] private string _name;
    [SerializeField] private string _message;

    public bool Equals(FeedbackMessage other)
    {
        return base.Equals(other) && _id == other._id && _name == other._name && _message == other._message;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((FeedbackMessage)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), _id, _name, _message);
    }
}
