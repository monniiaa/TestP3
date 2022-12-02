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
    Queue<AudioClip> clipQueue;
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
    public void PlayWithDelay(int soundnumber, AudioSource source)
    {
        source.clip = audioclips[soundnumber];
        source.PlayDelayed(4);
    }
    public void PlaySound(int soundnumber, AudioSource source)
    {
        source.PlayOneShot(audioclips[soundnumber]);
    }
    void Start()
    { 
        StartCoroutine(PlayAudioSequentially());
    }
    public void StairSound()
    {
        StartCoroutine(PlayStairAudio());
    }
    public void EndOfStairSound()
    {
        StartCoroutine(PlayTrainLeavingAudio());
    }
    public void STrainLeaving()
    {
        StartCoroutine(PlaySTrainSounds());
    }

        IEnumerator PlayAudioSequentially()
        {
            yield return null;
            for (int i = 0; i < 3; i++)
            {
                narratorSource.clip = audioclips[i];
                narratorSource.Play();
                while (narratorSource.isPlaying)
                {
                    yield return null;
                }
            }
        }

        IEnumerator PlayStairAudio()
        {
            yield return null;
            for (int i = 3; i < 4; i++)
            {
                narratorSource.clip = audioclips[i];
                narratorSource.Play();
                while (narratorSource.isPlaying)
                {
                    yield return null;
                }
            }
        }
        IEnumerator PlayTrainLeavingAudio()
        {
            yield return null;
            for (int i = 4; i < 5; i++)
            {
                narratorSource.clip = audioclips[i];
                narratorSource.Play();
                while (narratorSource.isPlaying)
                {
                    yield return null;
                }
            }
        }
        IEnumerator PlaySTrainSounds()
        {
            yield return null;
            for (int i = 7; i < 9; i++)
            {
                narratorSource.clip = audioclips[i];
                narratorSource.Play();
                while (narratorSource.isPlaying)
                {
                    yield return null;
                }
            }
        }
}
