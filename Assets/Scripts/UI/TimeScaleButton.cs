using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeScaleButton : MonoBehaviour
{
    private enum GameSpeed
    {
        Normal,
        Fast,
        Paused
    }

    private static bool isFast;

    public void SetPause()
    {
        ChangeSpeed(GameSpeed.Paused);
    }

    public void SetFast()
    {
        ChangeSpeed(GameSpeed.Fast);
    }

    public void SetNormal()
    {
        ChangeSpeed(GameSpeed.Normal);
    }

    public void ResumeGame()
    {
        ChangeSpeed(isFast ? GameSpeed.Fast : GameSpeed.Normal);
    }

    private void ChangeSpeed(GameSpeed gameSpeed)
    {
        switch (gameSpeed)
        {
            case (GameSpeed.Normal):
                Time.timeScale = 1f;
                isFast = false;
                break;
            case (GameSpeed.Fast):
                Time.timeScale = 1.7f;
                isFast = true;
                break;
            case (GameSpeed.Paused):
                Time.timeScale = 0f;
                break;
                
        }
    }

}
