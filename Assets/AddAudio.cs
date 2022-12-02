using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAudio : MonoBehaviour
{
    public AudioClip[] audioClip;

    public AudiManagerHouse audioManager;

    bool HasTriggered = false;

    public string objecttag;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(objecttag))
        {
            if (!HasTriggered)
            {
                
                foreach(AudioClip clip in audioClip)
                    audioManager.EnqueueAudioClip(clip);
                HasTriggered = true;
            }
        }
    }

    
}
