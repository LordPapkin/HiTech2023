using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeScaleButton : MonoBehaviour
{
    private static bool isFast;
    
    public void SetPause()
    {
        GameStateManager.Instance.ChangeSpeed(GameStateManager.GameSpeed.Paused);
    }

    public void SetFast()
    {
        GameStateManager.Instance.ChangeSpeed(GameStateManager.GameSpeed.Fast);
        isFast = true;
    }

    public void SetNormal()
    {
        GameStateManager.Instance.ChangeSpeed(GameStateManager.GameSpeed.Normal);
        isFast = false;
    }

    public void ResumeGame()
    {
        GameStateManager.Instance.ChangeSpeed(isFast ? GameStateManager.GameSpeed.Fast : GameStateManager.GameSpeed.Normal);
    }

    

}
