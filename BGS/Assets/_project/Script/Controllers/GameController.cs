using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Action<bool> OnPlayerInInteraction;

    public static GameController Instance;

    private void Awake()
    {
        Instance = this;
    }
}
