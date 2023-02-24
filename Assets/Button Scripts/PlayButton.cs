using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public Button yourButton;

    public GameObject menuNothing;
    public GameObject menuPlay;
    public GameObject menuOptions;


    void Start()
    {
        menuNothing.SetActive(true);
        menuPlay.SetActive(false);
        menuOptions.SetActive(false);

        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        menuNothing.SetActive(false);
        menuPlay.SetActive(true);
        menuOptions.SetActive(false);
    }
    //public void OnClick()
    //{
    //    menuNothing.SetActive(false);
    //    menuPlay.SetActive(true);
    //    menuOptions.SetActive(false);
    //}

}
