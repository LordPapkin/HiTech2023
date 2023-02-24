using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    //template
    private static event Action OnSomethingHappen;

    public static void SomethingHappen()
    {
        OnSomethingHappen?.Invoke();
    }
}
