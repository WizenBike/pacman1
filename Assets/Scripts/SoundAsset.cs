using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class SoundAsset
{
    [SerializeField] string soundName;
    [SerializeField, Range(0, 1f)] float volume = 1f;
    [SerializeField] bool loop = false;
    [SerializeField] AudioClip clip;

    public float Play(AudioSource audioSource)
    {
        if (clip == null) return 0f;
        audioSource.clip = this.clip;
        audioSource.volume = this.volume;
        audioSource.loop = false;
        audioSource.Play();
        return clip.length;
    }
    public string GetName()
    {
        return soundName;
    }
    
}
