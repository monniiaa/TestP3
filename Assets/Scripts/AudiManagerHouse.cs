using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiManagerHouse : MonoBehaviour
{

    public AudioClip[] transferList;
    Queue<AudioClip> audioClips = new Queue<AudioClip>(2);


    public AudioSource audioPlayer;
    // Start is called before the first frame update

    private void Start()
    {
       foreach(AudioClip audio in transferList)
        {
            audioClips.Enqueue(audio);
        }
    }
    private void Update()
    {
        PlayAudio();
    }

    void PlayAudio()
    {
        if (!audioPlayer.isPlaying)
        {
            if (audioClips.Count != 0)
            {
                audioPlayer.PlayOneShot(audioClips.Dequeue());   
            }
        }
    }

    public void EnqueueAudioClip(AudioClip clip)
    {
        audioClips.Enqueue(clip);
    }

}
