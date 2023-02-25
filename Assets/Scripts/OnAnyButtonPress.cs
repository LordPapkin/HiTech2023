using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAnyButtonPress : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKey)
        {
            Debug.Log("Key has been pressed");
            return;
        }
    }
}
