using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public enum GameSpeed
    {
        Normal,
        Fast,
        Paused
    }
    
    public static GameStateManager Instance => instance;
    private static GameStateManager instance;

    public string TimeToWinString => TimeSpan.FromSeconds(timeToWin).ToString(@"mm\:ss");

    [SerializeField] private string levelName;
    [SerializeField] private float timeToWin;
    [SerializeField] private int enemyBaseHealth;

    [SerializeField] private GameObject win;
    [SerializeField] private GameObject lose;
    
    private int score;
    private int highScore;

    private int tutorialShownCount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        tutorialShownCount = PlayerPrefs.GetInt("tutorialCount" + levelName, 0);
        highScore = PlayerPrefs.GetInt("highScore"+levelName, 0);  
        Debug.Log("Current highscore: " + highScore);
    }

    private void Start()
    {
        if (tutorialShownCount == 0)
        {
            GameEvents.ShowTutorial();
            ChangeSpeed(GameSpeed.Paused);
        }
    }

    private void Update()
    {
        timeToWin -= Time.deltaTime;
        if (timeToWin < 0) 
            LostGame();
    }

    public void IncreaseTutorialShownCount()
    {
        tutorialShownCount++;
        PlayerPrefs.SetInt("tutorialCount" + levelName, tutorialShownCount);
        ChangeSpeed(GameSpeed.Normal);
    }

    public void BaseDamaged(int value)
    {
        enemyBaseHealth -= value;
        
        if(enemyBaseHealth < 0)
            WonGame();
    }
    
    public void ChangeSpeed(GameSpeed gameSpeed)
    {
        switch (gameSpeed)
        {
            case (GameSpeed.Normal):
                Time.timeScale = 1f;
                
                break;
            case (GameSpeed.Fast):
                Time.timeScale = 1.7f;
                
                break;
            case (GameSpeed.Paused):
                Time.timeScale = 0f;
                break;
        }
    }

    private void LostGame()
    {
        lose.SetActive(true);
    }

    private void WonGame()
    {
        win.SetActive(true);
    }
}
