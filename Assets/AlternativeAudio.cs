using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeAudio : MonoBehaviour

{
    public AudioSource audiosource;
    public AudioClip audioclip;
   void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf && !audiosource.isPlaying)
        {
            audiosource.PlayOneShot(audioclip);
            Destroy(this);
        }
    }
}
