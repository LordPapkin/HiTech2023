using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{

    void Update()
    {
        if (Input.anyKey)
        {
            //prze��cz scene UI na Menu G��wne
            Debug.Log("A key or mouse click has been detected");
        }
    }
}
