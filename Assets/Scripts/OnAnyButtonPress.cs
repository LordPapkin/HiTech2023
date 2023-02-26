using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnAnyButtonPress : MonoBehaviour
{
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
    void Update()
    {
        if (Input.anyKey)
        {
            MoveToScene(0);
        }
    }
}
