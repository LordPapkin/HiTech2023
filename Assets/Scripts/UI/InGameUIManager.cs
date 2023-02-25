using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIManager : MonoBehaviour
{
    private enum GameState
    {
        Normal,
        Fast,
        Pause
    }

    private bool isFast;

    private void Awake()
    {
        ChangeGameState(GameState.Normal);
    }

    public void SetFast()
    {
        ChangeGameState(GameState.Fast);
    }

    public void SetNormal()
    {
        ChangeGameState(GameState.Normal);
    }
    
    public void SetPause()
    {
        ChangeGameState(GameState.Pause);
    }

    public void ResumeGame()
    {
        if(isFast)
            SetFast();
        else
            SetNormal();
    }

    private void ChangeGameState(GameState targetState)
    {
        switch (targetState)
        {
            case(GameState.Normal):
                isFast = false;
                Time.timeScale = 1f;
                break;
            case(GameState.Fast):
                isFast = true;
                Time.timeScale = 1.5f;
                break;
            case(GameState.Pause):
                Time.timeScale = 0f;
                break;
        }
    }
}
