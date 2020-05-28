using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    public static MusicManager INSTANCE
    {
        get
        {
            return instance;
        }

    }

    private AudioSource globalSource;

    public AudioSource GlobalSource
    {
        get
        {
            return globalSource;
        }

        private set
        {
            globalSource = value;
        }
    }

    private void Start()
    {
        GlobalSource = GetComponent<AudioSource>();
        instance = this;
        GlobalSource.spatialBlend = 0f;
        GlobalSource.loop = true;
    }

    public void PlayMusic(AudioClip audioClip)
    {
        GlobalSource.clip = audioClip;
        GlobalSource.Play();
    }
}
