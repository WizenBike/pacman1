using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : Singleton<MusicPlayer>
{
    [SerializeField] GameObject audioPrefab;
    private Queue<AudioSource> audioSources;
    [SerializeField] int minSourcesCount=5;
    private void Awake()
    {
        audioSources = new Queue<AudioSource>();
        for(int i = 0; i < minSourcesCount; i++)
        {
            CreateAudioSource();
        }
    }

    private AudioSource CreateAudioSource()
    {
        AudioSource createdSource = Instantiate(audioPrefab, transform).GetComponent<AudioSource>();
        audioSources.Enqueue(createdSource);
        return createdSource;
    }

    public void PlaySound(string soundName)
    {
        SoundAsset soundAsset = SoundAssetManager.Instance.FindSoundAsset(soundName);
        if (soundAsset == null) 
        {
            return;
        } 
        AudioSource audioSource = GetFreeAudioSource();
        float timeToPlay=soundAsset.Play(audioSource);
        if (audioSource.loop)
        {
            timeToPlay = 99999;
        }
        StartCoroutine(DelayedSourceReturn(timeToPlay + 0.02f,audioSource));
    }

    //Adds AudioSource back to the Queue after the sound is finished playing
    IEnumerator DelayedSourceReturn(float timeDelayed, AudioSource audioSource)
    {
        yield return new WaitForSeconds(timeDelayed);
        audioSource.volume = 1;
        audioSource.clip = null;
        audioSources.Enqueue(audioSource);
    }
    //Returns unused AudioSource, if there are none free a new one is created
    private AudioSource GetFreeAudioSource()
    {
        AudioSource freeAudioSource;
        if (audioSources.Count > 0)
        {
            freeAudioSource = audioSources.Dequeue();
        }
        else
        {
            freeAudioSource = CreateAudioSource();
        }
        return freeAudioSource;
    }
}
