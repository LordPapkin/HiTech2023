using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timer;
    private GameStateManager gameStateManager;

    private void Start()
    {
        gameStateManager = GameStateManager.Instance;
    }

    private void Update()
    {
        timer.SetText(gameStateManager.TimeToWinString);
    }
}
