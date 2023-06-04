using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField]
    private AudioSource musicSource;
    [SerializeField]
    private AudioSource effectSource;
    [SerializeField]
    private AudioClip music1;
    [SerializeField]
    private AudioClip music2;
    [SerializeField]
    private AudioClip effect1;
    [SerializeField]
    private AudioClip effect2;

    private AudioClip lastClip;

    private void Start()
    {
        int number = Random.Range(1, 3);

        if (number == 1)
        {
            musicSource.PlayOneShot(music1);
            lastClip = music1;
        }
        else
        {
            musicSource.PlayOneShot(music2);
            lastClip = music2;
        }
    }

    private void Update()
    {
        if (musicSource.isPlaying != true)
        {
            PlayMusic();
        }
    }
    public void PlayMusic()
    {
        if (lastClip == music1)
        {
            musicSource.PlayOneShot(music2);
            lastClip = music2;
        }
        else
        {
            musicSource.PlayOneShot(music1);
            lastClip = music1;
        }
    }

    public void PlayGetPointEffect()
    {
        effectSource.PlayOneShot(effect1);
    }

    public void PlayLostLifeEffect()
    {
        effectSource.PlayOneShot(effect2, 0.3f);
    }
}
