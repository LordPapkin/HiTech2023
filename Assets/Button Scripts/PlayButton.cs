using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public Button yourButton;

    public GameObject menuNothing = GameObject.Find("MenuNoButtonsClicked");
    public GameObject menuPlay = GameObject.Find("MenuPlayClicked").GetComponent<GameObject>();


    void Start()
    {
        menuNothing.SetActive(true);
        menuPlay.SetActive(false);
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }
    public void OnClick()
    {
        
    }

}
