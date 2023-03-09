using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHelper : MonoBehaviour
{
    public AudioSource PlayClip2D(AudioClip clip, float volume)
    {
        //create
        GameObject audioObject = new GameObject("Audio2D");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        //configure
        audioSource.clip = clip;
        audioSource.volume = volume;
        //activate
        audioSource.Play();
        Object.Destroy(audioObject, clip.length);

        return audioSource;

    }

    public void PlayAudio(AudioClip clip)
    {
        PlayClip2D(clip, 1f);
    }

}
