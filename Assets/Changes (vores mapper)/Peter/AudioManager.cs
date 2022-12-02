using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;



public class AudioManager : MonoBehaviour
{
    //public Sound[] sounds;
    public AudioClip[] audioclips;

    public static AudioManager instance;

    public AudioSource narratorSource;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        // lives through transitioning
        DontDestroyOnLoad(gameObject);
        /*foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }*/
    }

    void Start()
    {
        PlayWithDelay(0, narratorSource);
        
    }

    public void PlaySound(int soundnumber, AudioSource source)
    {
        source.PlayOneShot(audioclips[soundnumber]);
    }
    public void PlayWithDelay(int soundnumber, AudioSource source)
    {
        source.clip = audioclips[soundnumber];
        source.PlayDelayed(4);
    }
    /*public void Play(string name)
    {
        Sound snd = Array.Find(sounds, sound => sound.name == name);
        try
        {
            snd.source.Play();
        }
        catch (Exception exception)
        {
            Debug.LogWarning("sound not found");
        }
    
        
    }*/
}
