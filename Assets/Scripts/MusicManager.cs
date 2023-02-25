using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public float volumeLevel = 1f;
    public AudioSource Source;
    public AudioClip ClipWithIntro;
    public AudioClip Loop;
    void Start()
    {
        Source = GetComponent<AudioSource>();
        Source.clip = ClipWithIntro;
        Source.Play();
    }

    private void Awake()
    {
        Source.volume = volumeLevel;
    }

    private void Update()
    {
        if (!Source.isPlaying)
        {
            Source.clip = Loop;
            Source.Play();
        }
    }
}
