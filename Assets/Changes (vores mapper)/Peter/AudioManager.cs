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
        //PlayWithDelay(0, narratorSource); 
        StartCoroutine(PlayAudioSequentially());
    }
    public void StairSound()
    {
        StartCoroutine(PlayStairAudio());
    }

    IEnumerator PlayAudioSequentially()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < 3; i++)
        {
            //2.Assign current AudioClip to audiosource
            narratorSource.clip = audioclips[i];

            //3.Play Audio
            narratorSource.Play();

            //4.Wait for it to finish playing
            while (narratorSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    IEnumerator PlayStairAudio()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 3; i < 4; i++)
        {
            //2.Assign current AudioClip to audiosource
            narratorSource.clip = audioclips[i];

            //3.Play Audio
            narratorSource.Play();

            //4.Wait for it to finish playing
            while (narratorSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
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
    }
