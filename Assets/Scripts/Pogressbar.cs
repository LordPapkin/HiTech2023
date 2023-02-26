using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pogressbar : MonoBehaviour
{
    public int min;
    public int max;
    public int current;
    public Image mask;
    public Image fill;
    public Color color;

    private void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float currentOffset = current - min;
        float maximumOffset = max - min;
        float fillAmount = currentOffset / maximumOffset;
        mask.fillAmount = fillAmount;

        fill.color = color;
    }
}
