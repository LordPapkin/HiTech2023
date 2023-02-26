using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UIElements;

public class LeanInAnnimation : MonoBehaviour
{
    void OnEnable()
    {
        transform.localScale = Vector2.zero;
        transform.LeanScale(Vector2.one, 0.8f).setIgnoreTimeScale(true);
    }
}
