using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager INSTANCE
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
    }

    public void PlaySound(AudioClip audioClip)
    {
        GlobalSource.clip = audioClip;
        GlobalSource.Play();
    }
}
