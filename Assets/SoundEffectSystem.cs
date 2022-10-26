using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectSystem : MonoBehaviour
{
    static public SoundEffectSystem Instance;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource endSong;
    void Start()
    {
        Instance = this;
        backgroundMusic.Play();
    }

    public void playEndSong(){
        endSong.Stop();
        backgroundMusic.Stop();
        endSong.Play();
    }
}
