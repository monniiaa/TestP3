using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDistance : MonoBehaviour
{
    public AudioSource sound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!sound.isPlaying)
            {
                sound.Play();
            }
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (sound.isPlaying)
            {
                sound.Stop();
            }
        }
    }*/ 
}
