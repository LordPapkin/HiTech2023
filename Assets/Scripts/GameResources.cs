using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResources : MonoBehaviour
{
    private static GameResources instance;

    public static GameResources Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<GameResources>("GameResources");
            }

            return instance;
        }
    }
    
    [field: SerializeField] public ResourcesListSO ResourcesList { get; private set; }
    [field: SerializeField] public ResourceSO Cebulion { get; private set; }
    [field: SerializeField] public ResourceSO Oil { get; private set; }
}
