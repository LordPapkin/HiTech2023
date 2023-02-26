using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialUnit : BasicUnit
{
    public enum SpecialCase
    {
        Roomba=1,
        Drone=2,
        Kerfus=3
    }

    [SerializeField] private SpecialCase unitTier;
    private bool isHealer = false;
    private void Start()
    {
        switch (unitTier)
        {
            case SpecialCase.Roomba:
                damage = 60;
                //what is the purpose in any of this... ~suicide roomba
                break;
            case SpecialCase.Drone:
                damage = 50;
                unitMovementController.velocity = 18f;
                //speedo haiai
                break;
            case SpecialCase.Kerfus:
                damage = 50;
                isHealer = true;
                //lemme nurse you, nya
                break;
            default:
                return;
        }
    }
}
