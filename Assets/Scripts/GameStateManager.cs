using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance => instance;
    private static GameStateManager instance;

    public string TimeToWinString => TimeSpan.FromSeconds(timeToWin).ToString(@"mm\:ss");
    
    [SerializeField] private float timeToWin;
    [SerializeField] private int enemyBaseHealth;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        timeToWin -= Time.deltaTime;
        if (timeToWin < 0) 
            LostGame();
    }

    private void LostGame()
    {
        Debug.LogError("NO END GAME LOGIC!!!");
    }
}
