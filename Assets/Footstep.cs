using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Footstep : MonoBehaviour
{
    public AudioSource footsteepAudio;

    public AudioClip[] footsteeps;
    public float volume = 0.2f;


    private void Update()
    {
        if(gameObject.GetComponent<NPCAINav>().theAgent.remainingDistance > 0)
        {
            GenerateFootSteps();
        }  else if(gameObject.GetComponent<NPCAINav>().theAgent.remainingDistance <= 0)
        {
            footsteepAudio.Stop();
        }
    }
    public void GenerateFootSteps()
    {
        if (!footsteepAudio.isPlaying)
        {
            if (footsteeps.Length > 0)
            {
                var index = Random.Range(0, footsteeps.Length);
                footsteepAudio.PlayOneShot(footsteeps[index], volume);
            }
        }
       
    }
}
