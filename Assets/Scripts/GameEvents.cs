using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    //template
    public static event Action OnSomethingHappen;

    public static void SomethingHappen()
    {
        OnSomethingHappen?.Invoke();
    }

    public static event Action OnResourceAmountChange;

    public static void ResourceAmountChange()
    {
        OnResourceAmountChange?.Invoke();
    }

    public static event Action OnTutorialShow;

    public static void ShowTutorial()
    {
        OnTutorialShow?.Invoke();
    }
}
