using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilitiesClass 
{
    public static Vector3 GetRandomDir()
    {
        return new Vector3(Random.Range(-1f,-1f), 0 ,Random.Range(-1f,1f)).normalized;
    }
}
