using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private GameObject foreground;
    [SerializeField] private GameObject background;
    
    private void OnEnable()
    {
        GameEvents.OnTutorialShow += ShowTutorial;
    }

    private void OnDisable()
    {
        GameEvents.OnTutorialShow -= ShowTutorial;
    }

    public void TutorialEnds()
    {
        GameStateManager.Instance.IncreaseTutorialShownCount();
    }

    private void ShowTutorial()
    {
        foreground.SetActive(true);
        background.SetActive(true);
    }
}
