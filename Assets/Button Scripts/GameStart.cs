using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{

    void Update()
    {
        if (Input.anyKey)
        {
            //prze³¹cz scene UI na Menu G³ówne
            Debug.Log("A key or mouse click has been detected");
        }
    }
}
