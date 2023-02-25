using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum SFX
    {
        Gunshot=1,
        TowerShot=2,
        TowerDestroyed=3,
        TowerPlaced=4,
        RoombaBuilt=5,
        DroneBuilt=6,
        KerfusBuilt=7,
        EnemyBaseReached=8
    }

    public AudioSource Source;

    public Dictionary<SFX, AudioClip> ListSFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


