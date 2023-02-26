using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum SFX
    {
        Gunshot=0,
        TowerShot=1,
        TowerDestroyed=2,
        TowerPlaced=3,
        RoombaBuilt=4,
        DroneBuilt=5,
        KerfusBuilt=6,
        EnemyBaseReached=7,
        RoombaOnDeath=8,
        DroneOnDeath=9,
        KerfusOnDeath=10,
        MoneyClick=11
    }

    public AudioSource Source;
    public List<AudioClip> AudioClips;
    public Dictionary<SFX, AudioClip> ListSFX;
    // Start is called before the first frame update
    void Start()
    {
        ListSFX = new Dictionary<SFX, AudioClip>();
        int i = 1;
        foreach (AudioClip clip in AudioClips)
        {
            ListSFX.Add((SFX)i, clip);
            i++;
        }
    }

    public void PlayClip(SFX clip)
    {
        AudioClip tmp;
        if (ListSFX.TryGetValue(clip, out tmp))
        {
            Source.clip = tmp;
            Source.PlayOneShot(tmp);
        }
    }
}


