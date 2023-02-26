using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    [SerializeField] private GameObject newHighScoreUI;
    [SerializeField] private TextMeshProUGUI newHighScoreText;
    [SerializeField] private GameObject odlHighScoreUI;
    [SerializeField] private TextMeshProUGUI currentHighScoreText;
    [SerializeField] private TextMeshProUGUI yourScoreText;

    [SerializeField] private Pogressbar pogressbar;
    
    private int score;
    private int highScore;

    private int tutorialShownCount;
    private float startTime;
    private int startHp;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        tutorialShownCount = PlayerPrefs.GetInt("tutorialCount" + levelName, 0);
        highScore = PlayerPrefs.GetInt("highScore"+levelName, 0);  
        Debug.Log("Current highscore: " + highScore);
        startTime = timeToWin;
        startHp = enemyBaseHealth;
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
    
    public void AddScore(int value)
    {
        score += value;
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
        pogressbar.current = startHp - enemyBaseHealth;
        
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
        ChangeSpeed(GameSpeed.Paused);
    }

    private void WonGame()
    {
        win.SetActive(true);
        score += (int)(timeToWin / startTime * 20000f);
        bool isNewHighScore = score > highScore;
        if (isNewHighScore)
        {
            PlayerPrefs.SetInt("highScore"+levelName, score);
            newHighScoreUI.SetActive(true);
            newHighScoreText.SetText(score.ToString());
        }
        else
        {
            odlHighScoreUI.SetActive(true);
            currentHighScoreText.SetText(highScore.ToString());
            yourScoreText.SetText(score.ToString());
        }
        ChangeSpeed(GameSpeed.Paused);
    }
}
